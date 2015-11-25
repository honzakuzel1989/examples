#Get information about logical volumes

Get-WmiObject Win32_LogicalDisk | `Select -, Name, DriveType, FileSystem, FreeSpace, Size, -` | Format-Table -AutoSize