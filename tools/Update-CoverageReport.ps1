<#
.SYNOPSIS
Updates the coverage.md file in the source tree.

.PARAMETER Configuration
The build configuration to search for the exports and pinvokes files (e.g. "release").
#>
Param(
	[Parameter()]
	[string]$Configuration='release'
)

nuget restore "$PSScriptRoot\..\src" -Verbosity quiet
msbuild /nologo /m /v:minimal /fl "$PSScriptRoot\..\src\PInvoke.sln" /p:configuration=$Configuration /p:GeneratePInvokesTxt=true

$Shields = & "$PSScriptRoot\Get-Shields.ps1" -Directory "$PSScriptRoot\..\bin\$Configuration"
$CoveragePath = Resolve-Path "$PSScriptRoot\..\coverage.md"

Set-Content -Path $CoveragePath -Value "# P/Invoke coverage report

Coverage  | Package
----------|--------"

$Shields |% {
	$NuPkgId = "PInvoke.$($_.Subject)"
	Add-Content -Path $CoveragePath -Value "$($_.MarkDown) | [$($_.Subject)](https://www.nuget.org/packages/$NuPkgId)"
}
