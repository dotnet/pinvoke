<#
    .SYNOPSIS
    Adds the class library and NuGet projects necessary to support a new native library
    to the solution.

    .PARAMETER LibraryName
    The name of the library you are introducing support for, without the .dll extension.

    .EXAMPLE
    AddNewLibrary -LibraryName BCrypt
#>
[CmdletBinding()]
param(
    [Parameter(Mandatory=$true,Position=0)]
    [string]$LibraryName
)

if (!(Get-Command dumpbin)) {
    Write-Error "DUMPBIN must be on your path. Install the `"Desktop Development with C++`" workload and repeat this command within a VS 2017 Developer Command Prompt."
    return 1
}

. $PSScriptRoot\Replace-Placeholders.ps1

$Src = Resolve-Path "$PSScriptRoot\..\src"
$Test = Resolve-Path "$PSScriptRoot\..\test"

$Directories = 'LIBNAME','LIBNAME.Tests'
$SrcDirectories = @()
foreach($dir in $Directories) {
    $IsTest = $dir -Like '*test*'
    if ($IsTest) {
        $SrcDirectory = "$Test\$dir"
    } else {
        $SrcDirectory = "$Src\$dir"
    }
    $TemplateDirectory = "$PSScriptRoot\$dir"
    $SrcDirectory_Substituted = $SrcDirectory.Replace('LIBNAME', $LibraryName)
    If (-not (Test-Path $SrcDirectory_Substituted)) {
        $SrcDirectories += $SrcDirectory
    }
    Copy-Item -Recurse -Path $TemplateDirectory -Destination $SrcDirectory
}

$Replacements = @{
    'LIBNAME' = $LibraryName;
}

$SrcDirectories |% { Replace-Placeholders -LibraryName $LibraryName -Replacements $Replacements -Path $_ }

& "$PSScriptRoot\CreateExportsTxtFile.ps1" -AssemblyPath "$env:windir\System32\$LibraryName.dll" -OutputDir "$Src\$LibraryName\"

dotnet sln $PSScriptRoot\.. add $Src\$LibraryName  --in-root
dotnet sln $PSScriptRoot\.. add $Test\$LibraryName.Tests --in-root
dotnet add $Src\win32 reference $Src\$LibraryName

Write-Output "Great. Your new projects have been created. Please also perform a few more manual steps:"
Write-Output "1. Add your library to the README.md file."
