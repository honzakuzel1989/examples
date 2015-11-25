#Advanced function (with default params etc.)
function Get-FreeDiskSpace
{
	param ($drive='C:', [switch]$gb, [switch]$mb)
	$filter='DeviceID="'+$drive+'"'
	$sws=""
	if($gb) {
		(Get-WmiObject Win32_LogicalDisk -Filter $filter).FreeSpace/1GB
	}
	else {
		if($mb) {
			(Get-WmiObject Win32_LogicalDisk -Filter $filter).FreeSpace/1MB
		}
		else{
			(Get-WmiObject Win32_LogicalDisk -Filter $filter).FreeSpace
		}
	}
}

#For cycle through logical volumes
$disks=Get-WmiObject Win32_LogicalDisk | Select DeviceID
for($i=0; $i -lt $disks.Count; $i++){
	$disk=$disks[$i].DeviceID
	$aux=$disk + " " + (Get-FreeDiskSpace $disk -mb)
	echo $aux
}
