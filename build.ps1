<#
.Synopsis
    Acquires dependencies, builds, and tests this project.
.Description
    If no actions are specified, the default is to run all actions.
.Parameter Restore
    Restore NuGet packages.
.Parameter Build
    Build the entire project. Requires that -Restore is or has been executed.
.Parameter Test
    Run all built tests.
.Parameter Configuration
    The configuration to build. Either "debug" or "release". The default is debug, or the Configuration environment variable if set.
.Parameter WarnAsError
    Converts all build warnings to errors. Useful in preparation to sending a pull request.
#>
[CmdletBinding(SupportsShouldProcess=$true,ConfirmImpact='Medium')]
Param(
    [switch]$Restore,
    [switch]$Build,
    [switch]$Test,
    [Parameter()][ValidateSet('debug', 'release')]
    [string]$Configuration = $env:configuration,
    [switch]$WarnAsError = $true
)

if (!$Configuration) { $Configuration = 'debug' }

$NothingToDo = !($Restore -or $Build -or $Test)
if ($NothingToDo) {
    Write-Output "No actions specified. Applying default actions."
    $Restore = $true
    $Build = $true
    $Test = $true
}

# External dependencies
$sourceNugetExe = "https://dist.nuget.org/win-x86-commandline/v3.3.0/nuget.exe"

# Path variables
$ProjectRoot = Split-Path -parent $PSCommandPath
$SolutionFolder = Join-Path $ProjectRoot src
$SolutionFile = Join-Path $SolutionFolder "PInvoke.sln"
$ToolsFolder = Join-Path $ProjectRoot tools
$BinFolder = Join-Path $ProjectRoot "bin"
$BinConfigFolder = Join-Path $BinFolder $Configuration
$BinTestsFolder = Join-Path $BinConfigFolder "tests"
$PackageRestoreRoot = Join-Path $env:userprofile '.nuget/packages/'

# Set script scope for external tool variables.
$MSBuildCommand = Get-Command MSBuild.exe -ErrorAction SilentlyContinue

Function Get-ExternalTools {
    if (!$MSBuildCommand) {
        Write-Error "Unable to find MSBuild.exe. Make sure you're running in a VS Developer Prompt."
        exit 1;
    }
}

Get-ExternalTools

if ($Restore -and $PSCmdlet.ShouldProcess($SolutionFile, "Restore packages")) {
    Write-Output "Restoring NuGet packages..."
    & $MSBuildCommand.Path /t:restore /nologo /m $SolutionFile
    & $MSBuildCommand.Path /t:restore /nologo /m "$SolutionFolder\NtDll.Tests\NtDll.Tests.csproj"
    & $MSBuildCommand.Path /t:restore /nologo /m "$SolutionFolder\WtsApi32.Tests\WtsApi32.Tests.csproj"
}

if ($Build -and $PSCmdlet.ShouldProcess($SolutionFile, "Build")) {
    Write-Output "Building..."
    & $MSBuildCommand.Path $SolutionFile /nologo /nr:false /m /v:minimal /fl /t:build,pack "/flp:verbosity=normal;logfile=msbuild.log" "/flp1:warningsonly;logfile=msbuild.wrn;NoSummary;verbosity=minimal" "/flp2:errorsonly;logfile=msbuild.err;NoSummary;verbosity=minimal"
    $fail = $false

    $warnings = Get-Content msbuild.wrn
    $errors = Get-Content msbuild.err
    $WarningsPrompt = "$(($warnings | Measure-Object -Line).Lines) warnings during build"
    $ErrorsPrompt = "$(($errors | Measure-Object -Line).Lines) errors during build"
    if ($errors.length -gt 0) {
        Write-Error $ErrorsPrompt
        $fail = $true
    } else {
        Write-Output $ErrorsPrompt
    }

    if ($WarnAsError -and $warnings.length -gt 0) {
        Write-Error $WarningsPrompt
        $fail = $true
    } elseif ($warnings.length -gt 0) {
        Write-Warning $WarningsPrompt
    } else {
        Write-Output $WarningsPrompt
    }

    if ($fail) {
        exit 3;
    }
}

if ($Test -and $PSCmdlet.ShouldProcess('Test assemblies')) {
    $TestAssemblies = Get-ChildItem -Recurse "$BinTestsFolder\*.Tests.dll"
    Write-Output "Testing..."
    $xunitRunner = Join-Path $PackageRestoreRoot 'xunit.runner.console/2.2.0/tools/xunit.console.x86.exe'
    & $xunitRunner $TestAssemblies -nologo -html "$BinTestsFolder\testresults.html" -xml "$BinTestsFolder\testresults.xml" -parallel all
}
