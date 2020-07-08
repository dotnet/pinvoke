Get-ChildItem "$PSScriptRoot\..\src\PublicAPI.Unshipped.txt" -Recurse |% {
    $unshippedAPIs = @(Get-Content -Path $_)
    if ($unshippedAPIs.Length -gt 0) {
        $LibName = Split-Path (Split-Path $_) -Leaf
        Write-Host "Promoting $($unshippedAPIs.Length) APIs from $LibName"
        Set-Content -Path $_ -Value @()
        $ShippedApiPath = Join-Path (Split-Path $_) PublicAPI.Shipped.txt
        $shippedAPIs = @(Get-Content -Path $ShippedApiPath)
        Set-Content -Path $ShippedApiPath -Value ($shippedAPIs + $unshippedAPIs)
    }
}
