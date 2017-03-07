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

$Directories = 'LIBNAME','LIBNAME.Tests'
$TemplateDirectories = @()
$SrcDirectories = @()
foreach($dir in $Directories) {
    $SrcDirectory = "$Src\$dir"
    $TemplateDirectory = "$PSScriptRoot\$dir"
    $SrcDirectory_Substituted = $SrcDirectory.Replace('LIBNAME', $LibraryName)
    If (-not (Test-Path $SrcDirectory_Substituted)) {
        $TemplateDirectories += $TemplateDirectory
        $SrcDirectories += $SrcDirectory
    }
}

$Replacements = @{
    'LIBNAME' = $LibraryName;
}

Copy-Item -Recurse -Path $TemplateDirectories -Destination $Src
$SrcDirectories |% { Replace-Placeholders -LibraryName $LibraryName -Replacements $Replacements -Path $_ }

& "$PSScriptRoot\CreateExportsTxtFile.ps1" -AssemblyPath "$env:windir\System32\$LibraryName.dll" -OutputDir "$Src\$LibraryName\"

Write-Output "Great. Your new projects have been created. Please also perform a few more manual steps:"
Write-Output "1. Add these new projects to your solution file:"
Write-Output "    $Src\$LibraryName\$LibraryName.csproj"
Write-Output "    $Src\$LibraryName.Tests\$LibraryName.Tests.csproj"
Write-Output "2. Add your library to the README.md file."
Write-Output "3. Add a project reference to $Src\$CoreLibraryName\$CoreLibraryName.csproj"
Write-Output "   into the Win32 project, if it's part of the Win32 API."
