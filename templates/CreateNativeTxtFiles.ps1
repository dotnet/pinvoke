<#
.SYNOPSIS
Export all "export functions" from a native Win32 dll.
.DESCRIPTION
TODO
.PARAMETER AssemblyPath
The path, including the file name, of the Win32 dll from which the "export functions" name will be exported.
.PARAMETER OutputPath
The path where the result file (LIBNAME.exports.txt) will be created.
#>
Param(
    [Parameter(Mandatory=$true)]
    [string]$AssemblyPath,
    [Parameter()]
    [string]$OutputPath='.'
)


if (Test-Path $AssemblyPath) {

    $exportedMethods = New-Object 'System.Collections.Generic.Dictionary[string,string]'
    $fullMethodList = New-Object 'System.Collections.Generic.List[string]'

    dumpbin /exports $AssemblyPath | 
    Where { $_ -match '\s+\d+\s+[A-Z0-9]+\s+[A-Z0-9\s]{8}\s{1}(?<MethodName>\w+)' } |
    Foreach-Object { 

        $methodname = $matches['MethodName']
         
        if($methodname.EndsWith('A') -or $methodname.EndsWith('W')) {

            $rootName = $methodname.Substring(0, $methodname.Length - 1)
            $endingLetter = $methodname[$methodname.Length - 1]

            if ($exportedMethods.ContainsKey($rootName)){
                $exportedMethods[$rootName] = ""    
            }
            else{
                $exportedMethods[$rootName] = $endingLetter 
            }
        }
        else{
            $exportedMethods[$methodname] = ""
        }        
    }

    if ($exportedMethods.Count -gt 0) {
        $OutputPath = Resolve-Path $OutputPath
        $LibraryName = [System.IO.Path]::GetFileNameWithoutExtension($AssemblyPath);
        $filePath = [System.IO.Path]::Combine($OutputPath, $LibraryName + '.exports.txt')
        
        Set-Content $filePath ($exportedMethods.GetEnumerator() | % { $_.Key+$_.Value } | Sort-Object)
        Write-Output "Method names exported to $filePath"
		Write-Output "Please add the $LibraryName.exports.txt to either the $LibraryName.Desktop or $LibraryName project as appropriate."
		Write-Output "Make be sure this file gets copied as a build output."
    }
}
else{
    Write-Error "Cannot find assembly file: $AssemblyPath"
}