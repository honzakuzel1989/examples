#Terminate the proces

$process=$args[0]
Get-Process -Name $process | Stop-Process 