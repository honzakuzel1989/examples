#WMI = Windows Managment Instrumentation
echo Computer:
echo ---------
Get-WmiObject Win32_ComputerSystem

echo System:
echo -------
Get-WmiObject Win32_OperatingSystem