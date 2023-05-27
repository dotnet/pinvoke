<#
.SYNOPSIS
Exports all the static methods names (independent of their visibility) that have [DllImport] attributes on them.
If the DllImport.EntryPoint property is found that will be the value exported otherwise the method name.
.PARAMETER AssemblyPath
The path, including the file name, of the PInvoke lib from which the methods name will be exported.
#>
Param(
    [Parameter(Mandatory=$true)]
    [string]$AssemblyPath
)

$exportedMethods = @()

if (Test-Path $AssemblyPath) {
    Add-Type -LiteralPath $AssemblyPath -PassThru |% {
        $_.GetMethods($([Reflection.BindingFlags]'NonPublic,Public,Static')) | Where {!$_.GetMethodBody()} |% {
            $attribute = $_.GetCustomAttributes([System.Runtime.InteropServices.DllImportAttribute], $false) | Select -First 1
            if ($attribute){
                $exportedMethods += $attribute.EntryPoint
            }
        }
    }
}
else {
    Write-Error "Unable to find file $AssemblyPath."
}
if ($exportedMethods.Count -gt 0) {
    $fileName = (Get-Item $AssemblyPath).Basename -replace "PInvoke.", ""
    $filePath = Join-Path (Get-Item $AssemblyPath).DirectoryName "$fileName.pinvokes.txt";
    Set-Content $filePath ($exportedMethods | Sort-Object)
    Write-Verbose "P/Invoke method names written to $filePath"
} else {
    Write-Verbose "No P/Invoke methods found for $AssemblyPath."
}
