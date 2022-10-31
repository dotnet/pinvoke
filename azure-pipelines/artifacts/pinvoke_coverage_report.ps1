$RepoRoot = [System.IO.Path]::GetFullPath("$PSScriptRoot\..\..")
$BuildConfiguration = $env:BUILDCONFIGURATION
if (!$BuildConfiguration) {
    $BuildConfiguration = 'Debug'
}

$binRoot = "$RepoRoot\bin\$BuildConfiguration"

& "$PSScriptRoot\..\..\tools\Get-CoverageReport.ps1" -NoBuild -Configuration $env:configuration -OutFile "$binRoot\coverage.md"

& (& "$PSScriptRoot\..\Get-pandoc.ps1") -f markdown -t html "$binRoot\coverage.md" -o "$binRoot\coverage.html"

@{
    $binRoot = Get-ChildItem "$binRoot\coverage.html","$binRoot\coverage.md";
}
