#Sources:
# ss64.com/ps/call.html
# 

$scriptPath = Split-Path $MyInvocation.InvocationName

#The call operator (&) to force PowerShell to treat the string as a command to be executed.
#& $myVar with scriptblock
#& {Scriptblock} scriptblock directly
#
#This usage (calling a script block) is similar to using Invoke-Expression to run a set 
#of commands but has a key difference in that the & call operator will create an additional (child) scope, 
#while Invoke-Expression will not. 
#
#Invoking a command (either directly or with the call operator) will create a child scope 
#that will be thrown away when the command exits. If the command/script changes a global 
#variable those changes will be lost when the scope ends.
#To avoid this and preserve any changes made to global variables you can 'dot' the script 
#which will execute the script in the current scope.

echo "Init action..."

# block current script
if(Test-Path subscript-pre.ps1){
    . "$scriptPath\subscript-pre.ps1"
}

echo "Some action..."

# block current script
if(Test-Path subscript-post.ps1){
    . "$scriptPath\subscript-post.ps1"
}

echo "End action..."