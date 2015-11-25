#Creating a new object
$info=New-Object PSObject -Property @{App='app'; Account='acc'; Status='100'}
$info.App
$info.Account
$info.Status