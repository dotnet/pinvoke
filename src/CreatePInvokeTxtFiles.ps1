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
$sb = New-Object -TypeName "System.Text.StringBuilder"

if (Test-Path $AssemblyPath){
	Write-Host "Exporting P/Invoke methods from -> $AssemblyPath"
	$assembly = [Reflection.Assembly]::LoadFrom($AssemblyPath)
	$assembly.GetTypes() | Where-Object { $assembly.FullName.StartsWith($_.FullName) } | ForEach-Object {
        $_.GetMethods([Reflection.BindingFlags]::NonPublic -bor [Reflection.BindingFlags]::Public -bor [Reflection.BindingFlags]::Static) | Where-Object {!$_.GetMethodBody()} | Sort-Object -property Name | ForEach-Object {
			$attibute = $_.GetCustomAttributes([System.Runtime.InteropServices.DllImportAttribute], $false) | Select -First 1
			if ($attibute){
				if(!$attibute.EntryPoint) {
					[void]$sb.AppendLine($_.Name)
				} else { 
					[void]$sb.AppendLine($attibute.EntryPoint) 
				}
			}
       }
   }
}
else{
    Write-Error "Unable to find file $AssemblyPath."
}
if ($sb.Length -gt 0) {
    $fileName = $AssemblyPath.Replace(".dll", ".pinvokes.txt");
    [System.IO.File]::WriteAllText($fileName, $sb.ToString());
}