<#
.SYNOPSIS
Updates the coverage.md file in the source tree.

.PARAMETER Configuration
The build configuration to search for the exports and pinvokes files (e.g. "release").
.PARAMETER NoBuild
Skips the build and just harvests the files from a previously completed build.
.PARAMETER OutFile
The file to write the report to. If omitted, the report is returned as a string object to the caller.
#>
Param(
	[Parameter()]
	[string]$Configuration='release',
    [Parameter()]
    [switch]$NoBuild,
    [Parameter()]
    [string]$OutFile
)

if (!$NoBuild) {
    & "$PSScriptRoot\..\Build.ps1" -Restore -Build -GeneratePInvokesTxt -Configuration $Configuration
}

$Shields = & "$PSScriptRoot\Get-Shields.ps1" -Directory "$PSScriptRoot\..\bin\$Configuration"

$version = & (& "$PSScriptRoot\..\azure-pipelines\Get-nbgv.ps1") get-version -p "$PSScriptRoot\.." -v SemVer2
$commit = & (& "$PSScriptRoot\..\azure-pipelines\Get-nbgv.ps1") get-version -p "$PSScriptRoot\.." -v GitCommitId
$report = "# P/Invoke coverage report

Coverage  | Package
----------|--------
"

$Shields |% {
	$NuPkgId = "PInvoke.$($_.Subject)"
	$report += "$($_.MarkDown) | [$($_.Subject)](https://www.nuget.org/packages/$NuPkgId)
"
}

$report += "
Produced for v$version ($commit)
"

if ($OutFile) {
    Set-Content -Path $OutFile -Value $report
} else {
    $report
}
