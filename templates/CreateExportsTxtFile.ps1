﻿<#
.SYNOPSIS
Export all "export functions" from a native Win32 dll.
.PARAMETER AssemblyPath
The path, including the file name, of the Win32 dll from which the "export functions" name will be exported.
.PARAMETER OutputDir
The path to the directory where the result file (LIBNAME.exports.txt) will be created.
#>
[CmdletBinding()]
Param(
    [Parameter(Mandatory=$true,Position=0)]
    [string[]]$AssemblyPaths,
    [Parameter()]
    [string]$OutputDir='.'
)

function Get-ExportFunctions {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory=$true)]
        [string]$AssemblyPath
    )

    $exportedMethods = New-Object 'System.Collections.Generic.Dictionary[string,string]'

    dumpbin /exports $AssemblyPath |? { $_ -match '\s+\d+\s+[A-Z0-9]+\s+[A-Z0-9\s]{8}\s{1}(?<MethodName>\w+)' } |% {
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
    return $exportedMethods.GetEnumerator() | % { $_.Key+$_.Value }
}

$AssemblyPaths |% {
    if(!(Test-Path $_)){
        Write-Warning "Cannot find assembly file: $_"
        return
    }

    $OutputDir = Resolve-Path $OutputDir
    $LibraryName = [System.IO.Path]::GetFileNameWithoutExtension($_);
    $filePath = [System.IO.Path]::Combine($OutputDir, "$LibraryName.exports.txt")

    Set-Content $filePath (Get-ExportFunctions -AssemblyPath $_ | Sort-Object)
    Write-Output "Method names exported to $filePath"
}
