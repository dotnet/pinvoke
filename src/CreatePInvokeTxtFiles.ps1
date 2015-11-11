<#
.SYNOPSIS
Exports all the static methods names (independent of their visibility) that have [DllImport] attributes on them.
If the DllImport.EntryPoint property is found that will be the value exported otherwise the method name.
.DESCRIPTION
TODO
.PARAMETER AssemblyPath
The path, including the file name, of the PInvoke lib from which the methods name will be exported.
#>
Param(
    [Parameter(Mandatory=$true)]
    [string]$AssemblyPath
)
$exportedMethods = New-Object 'System.Collections.Generic.List[string]'

if (Test-Path $AssemblyPath) {
	Write-Host "Exporting P/Invoke methods from -> $AssemblyPath"
	$assembly = [Reflection.Assembly]::LoadFrom($AssemblyPath)
	$assembly.GetTypes() | Where-Object { $assembly.FullName.StartsWith($_.FullName) } | ForEach-Object {
		$_.GetMethods([Reflection.BindingFlags]::NonPublic -bor [Reflection.BindingFlags]::Public -bor [Reflection.BindingFlags]::Static) | Where-Object {!$_.GetMethodBody()} | ForEach-Object {
			$attribute = $_.GetCustomAttributes([System.Runtime.InteropServices.DllImportAttribute], $false) | Select -First 1
			if ($attribute){
				if(!$attribute.EntryPoint) {
					$exportedMethods.Add($_.Name)
				} else { 
					$exportedMethods.Add($attribute.EntryPoint) 
				}
			}
		}
	}
}
else {
    Write-Error "Unable to find file $AssemblyPath."
}
if ($exportedMethods.Count -gt 0) {
	$fileName = [System.IO.Path]::GetFileNameWithoutExtension($AssemblyPath).Replace("PInvoke.", "")
	$filePath = [System.IO.Path]::Combine([System.IO.Path]::GetDirectoryName($AssemblyPath), "$fileName.pinvokes.txt");
    Add-Content $filePath ($exportedMethods | Sort-Object)
}