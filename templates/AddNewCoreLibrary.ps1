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
function Replace-Placeholders {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory=$true)]
        [string]$Path,
        [Parameter(Mandatory=$true)]
        [string]$LibraryName,
        [Parameter(Mandatory=$true)]
        $Replacements
    )

    Get-ChildItem -Recurse $Path -File |% {
        $content = Get-Content -Path $_.FullName
        $Replacements.GetEnumerator() |% { $content = $content -replace $_.Key,$_.Value }
        Set-Content -Path $_.FullName -Value $content -Encoding UTF8

        if ($_.Name -match 'LIBNAME') {
            $NewLeafName = $_.Name -Replace 'LIBNAME',$LibraryName
            Rename-Item $_.FullName $NewLeafName
        }
    }

    # Rename directories
    Get-ChildItem -Recurse $Path -Directory |% {
        if ($_.Name -match 'LIBNAME') {
            $NewLeafName = $_.Name -Replace 'LIBNAME',$LibraryName
            Rename-Item $_.FullName $NewLeafName
        }
    }

    # Finally, rename $Path itself
    $NewLeafName = (Split-Path -Leaf $Path) -Replace 'LIBNAME',$LibraryName
    Rename-Item $Path $NewLeafName
}

$Src = Resolve-Path "$PSScriptRoot\..\src"

$Directories = 'LIBNAME','LIBNAME.Profile111','LIBNAME.Desktop','LIBNAME.Shared','LIBNAME.NuGet'
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
    '\$guid1\$' = [Guid]::NewGuid().ToString('b').ToUpper();
    '\$guid2\$' = [Guid]::NewGuid().ToString('b').ToUpper();
    '\$guid3\$' = [Guid]::NewGuid().ToString('b').ToUpper();
    '\$guid4\$' = [Guid]::NewGuid().ToString('b').ToUpper();
    '\$guid5\$' = [Guid]::NewGuid().ToString('b').ToUpper();
    '\$guid6\$' = [Guid]::NewGuid().ToString('b').ToUpper();
    'LIBNAME' = $CoreLibraryName;
}

Copy-Item -Recurse -Path $TemplateDirectories -Destination $Src
$SrcDirectories |% { Replace-Placeholders -LibraryName $CoreLibraryName -Replacements $Replacements -Path $_ }

Write-Output "Great. Your new projects have been created. Please also perform a few more manual steps:"
Write-Output "1. Add these new projects to your solution file:"
Write-Output "    $Src\$CoreLibraryName\$CoreLibraryName.csproj"
Write-Output "    $Src\$CoreLibraryName.Profile111\$CoreLibraryName.Profile111.csproj"
Write-Output "    $Src\$CoreLibraryName.Desktop\$CoreLibraryName.Desktop.csproj"
Write-Output "    $Src\$CoreLibraryName.Shared\$CoreLibraryName.Shared.shproj"
Write-Output "    $Src\$CoreLibraryName.NuGet\$CoreLibraryName.NuGet.nuproj"
Write-Output "2. Add your library to the README.md file."
Write-Output "3. Add a project reference to $Src\$CoreLibraryName.NuGet\$CoreLibraryName.NuGet.nuproj"
Write-Output "   into the PInvoke.Win32.nuproj project, if it's part of the Win32 API."
