<#
.SYNOPSIS
Gets the shields for all libraries.

.PARAMETER Directory
The directory to search for the exports and pinvokes files (e.g. bin\debug).
#>
Param(
	[Parameter(Mandatory=$true,Position=0)]
	[string]$Directory
)

$Shields = @()
$pinvokeFiles = Get-ChildItem -Path "$Directory\*.pinvokes.txt" -Recurse
$pinvokeFiles |% {
	$null = $_.Name -Match "(?<Library>\w+)\.pinvokes.txt"
	$Library = $Matches.Library
	$ExportsPath = Join-Path $_.Directory "$Library.exports.txt"
	if (Test-Path $ExportsPath)	{
		$Shields += & "$PSScriptRoot\Get-Shield.ps1" -Directory $_.Directory -Library $Library
	}
}

$Shields | Sort-Object Subject
