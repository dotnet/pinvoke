<#
.SYNOPSIS
Updates the coverage.md file in the source tree.

.PARAMETER Directory
The directory to search for the exports and pinvokes files (e.g. bin\debug).
#>
Param(
	[Parameter(Mandatory=$true)]
	[string]$Directory
)

$Shields = & "$PSScriptRoot\Get-Shields.ps1" -Directory $Directory
$CoveragePath = Resolve-Path "$PSScriptRoot\..\coverage.md"

Set-Content -Path $CoveragePath -Value "# P/Invoke coverage report

Coverage  | Package
----------|--------"

$Shields |% {
	$NuPkgId = "PInvoke.$($_.Subject)"
	Add-Content -Path $CoveragePath -Value "$($_.MarkDown) | [$($_.Subject)](https://www.nuget.org/packages/$NuPkgId)"
}
