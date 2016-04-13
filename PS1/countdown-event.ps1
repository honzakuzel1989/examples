#Number of tick
$global:tick = 10
#Timer
$timer = New-Object timers.timer
#Interval
$timer.Interval = 1000
#Event
Register-ObjectEvent -InputObject $timer -EventName Elapsed -Action {
    #Event handler
    Write-Host $global:tick
    if($global:tick-- -eq 0)
    {
        #Stop
        $timer.Stop()
    }
}
#Start
$timer.Enabled = $True