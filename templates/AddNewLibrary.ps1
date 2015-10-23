[CmdletBinding()]
param(
    [Parameter(Mandatory=$true,Position=0)]
    [string]$LibraryName
)
<#
    .SYNOPSIS
    #>

function Replace-Placeholders {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory=$true)]
        [string]$LibraryName,
        [Parameter(Mandatory=$true)]
        [string]$Path
    )

    Get-ChildItem -Recurse $Path -File |% {
        $guid1 = [Guid]::NewGuid()
        $guid2 = [Guid]::NewGuid()

        $content = Get-Content -Path $_.FullName
        $content = $content -replace 'LIBNAME',$LibraryName
        $content = $content -replace '\$guid1\$',$guid1
        $content = $content -replace '\$guid2\$',$guid2

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

Copy-Item -Recurse -Path "$PSScriptRoot\PInvoke.LIBNAME","$PSScriptRoot\PInvoke.LIBNAME.NuGet" -Destination $Src
Replace-Placeholders -LibraryName $LibraryName -Path $Src\PInvoke.LIBNAME
Replace-Placeholders -LibraryName $LibraryName -Path $Src\PInvoke.LIBNAME.NuGet

Write-Output "Great. Your two new projects have been created."
Write-Output "Please add these new projects to your solution file:"
Write-Output "    $Src\PInvoke.$LibraryName\PInvoke.$LibraryName.csproj"
Write-Output "    $Src\PInvoke.$LibraryName.NuGet\PInvoke.$LibraryName.NuGet.nuproj"
