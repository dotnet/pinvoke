$nuget = & "$PSScriptRoot\Get-NuGetTool.ps1"
$PandocVersion = "2.1.0"
$PandocExePath = "$PSScriptRoot\..\packages\Pandoc.Windows.$PandocVersion\tools\Pandoc\pandoc.exe"
if (!(Test-Path $PandocExePath)) {
    & $nuget install Pandoc.Windows -version $PandocVersion -Source https://api.nuget.org/v3/index.json | Out-Null
}

Resolve-Path "$PSScriptRoot\..\packages\Pandoc.Windows.$PandocVersion\tools\Pandoc\pandoc.exe"
