#Get programs running after boot

Push-Location .

#Get items
cd HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\Run
Get-ItemProperty .


Pop-Location