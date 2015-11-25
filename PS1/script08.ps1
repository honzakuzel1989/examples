#Assigned class to the variable
Add-Type -assembly System.Windows.Forms
$msgbox = [System.Windows.Forms.MessageBox]
#And using static method
$msgbox::Show('Hello World')