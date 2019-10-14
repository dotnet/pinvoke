$RepoRoot = [System.IO.Path]::GetFullPath("$PSScriptRoot\..\..")
$BuildConfiguration = $env:BUILDCONFIGURATION
if (!$BuildConfiguration) {
    $BuildConfiguration = 'Debug'
}

$binRoot = "$RepoRoot\bin\$BuildConfiguration\net45"
if (Test-Path $binRoot) {
    $pinvokes = Get-ChildItem "$binRoot\*.pinvokes.txt","$binRoot\*.exports.txt" -rec |? { $_.directory -notmatch 'tests' }

    @{
        "$binRoot" = $pinvokes
    }
}
