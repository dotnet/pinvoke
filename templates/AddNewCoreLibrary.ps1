<#
    .SYNOPSIS
    Adds the class library and NuGet projects necessary to support a new core library
    to the solution.

    A Core Library on PInvoke project wording is a library that only contains types and structures,
    no functions, classes or methods. These kind of projects are meant to be used when types and
    structures must be shared among other high level projects, like SHCore and User32 share Windows.ShellScalingApi.

    Core Libraries should be named after their C/C++ header file names like ShellScalingApi.h

    .PARAMETER CoreLibraryName
    The name of the core library you are introducing support for, without the .dll extension.

    .EXAMPLE
    AddNewCoreLibrary -CoreLibraryName Windows.ShellScalingApi
#>
[CmdletBinding()]
param(
    [Parameter(Mandatory=$true,Position=0)]
    [string]$CoreLibraryName
)

. $PSScriptRoot\Replace-Placeholders.ps1

$Src = Resolve-Path "$PSScriptRoot\..\src"

$Directories = ,'LIBNAME'
$TemplateDirectories = @()
$SrcDirectories = @()
foreach($dir in $Directories) {
    $SrcDirectory = "$Src\$dir"
    $TemplateDirectory = "$PSScriptRoot\$dir"
    $SrcDirectory_Substituted = $SrcDirectory.Replace('LIBNAME', $CoreLibraryName)
    If (-not (Test-Path $SrcDirectory_Substituted)) {
        $TemplateDirectories += $TemplateDirectory
        $SrcDirectories += $SrcDirectory
    }
}

$Replacements = @{
    'LIBNAME' = $CoreLibraryName;
}

Copy-Item -Recurse -Path $TemplateDirectories -Destination $Src
$SrcDirectories |% { Replace-Placeholders -LibraryName $CoreLibraryName -Replacements $Replacements -Path $_ }

dotnet sln $PSScriptRoot\.. add $Src\$CoreLibraryName --in-root
dotnet add $Src\win32 reference $Src\$CoreLibraryName

Write-Output "Great. Your new projects have been created. Please also perform a few more manual steps:"
Write-Output "1. Add your library to the README.md file."
