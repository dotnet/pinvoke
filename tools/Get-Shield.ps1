<#
.SYNOPSIS
Compares a LIBNAME.exports.txt file to a LIBNAME.pinvokes.txt file and
produces a string that may produce a shield/badge for online viewing.

.PARAMETER Directory
The directory where the exports and pinvokes files are to be found.

.PARAMETER Library
The simple name of the library (without the file extension). 
#>
Param(
	[Parameter(Mandatory=$true)]
	[string]$Directory,
	[Parameter(Mandatory=$true)]
	[string]$Library
)

Function Get-ShieldColor {
	[CmdletBinding()]
	Param(
		$ExportCount,
		$PInvokeCount
	)

	$coverage = 100 * $PInvokeCount / $ExportCount
	if ($coverage -eq 100) {
		"green"
	} elseif ($coverage -ge 70) {
		"yellowgreen"
	} elseif ($coverage -ge 30) {
		"orange"
	} elseif ($coverage -gt 0) {
		"red"
	} else {
		"lightgrey"
	}
}

$ExportsPath = Join-Path $Directory "$Library.exports.txt"
$PInvokesPath = Join-Path $Directory "$Library.pinvokes.txt"
	
$shield = New-Object PSObject
Add-Member -InputObject $shield -Name Subject -Value $Library -MemberType NoteProperty

$exportCount = (Get-Content -Path $ExportsPath).Count
$pinvokeCount = (Get-Content -Path $PInvokesPath).Count
Add-Member -InputObject $shield -Name Status -Value "$pinvokeCount/$exportCount" -MemberType NoteProperty

$color = Get-ShieldColor -ExportCount $exportCount -PInvokeCount $pinvokeCount
Add-Member -InputObject $shield -Name Color -Value $color -MemberType NoteProperty

$tuple = "$($shield.subject)-$($shield.status)-$($shield.color)"
Add-Member -InputObject $shield -Name Tuple -Value $tuple -MemberType NoteProperty

$svg = "https://img.shields.io/badge/$tuple.svg"
Add-Member -InputObject $shield -Name Svg -Value $svg -MemberType NoteProperty

$MarkDown = "![P/Invokes]($svg)"
Add-Member -InputObject $shield -Name MarkDown -Value $MarkDown -MemberType NoteProperty

return $shield
