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

$Directories = 'PInvoke.LIBNAME','PInvoke.LIBNAME.Tests','PInvoke.LIBNAME.NuGet'
$TemplateDirectories = $Directories |% { "$PSScriptRoot\$_" }
$SrcDirectories = $Directories |% { "$Src\$_" }

$Replacements = @{
    '\$guid1\$' = [Guid]::NewGuid().ToString('b').ToUpper();
    '\$guid2\$' = [Guid]::NewGuid().ToString('b').ToUpper();
    '\$guid3\$' = [Guid]::NewGuid().ToString('b').ToUpper();
    'LIBNAME' = $LibraryName;
}

Copy-Item -Recurse -Path $TemplateDirectories -Destination $Src
$SrcDirectories |% { Replace-Placeholders -LibraryName $LibraryName -Replacements $Replacements -Path $_ }

Write-Output "Great. Your two new projects have been created."
Write-Output "Please add these new projects to your solution file:"
Write-Output "    $Src\PInvoke.$LibraryName\PInvoke.$LibraryName.csproj"
Write-Output "    $Src\PInvoke.$LibraryName.Tests\PInvoke.$LibraryName.Tests.csproj"
Write-Output "    $Src\PInvoke.$LibraryName.NuGet\PInvoke.$LibraryName.NuGet.nuproj"
