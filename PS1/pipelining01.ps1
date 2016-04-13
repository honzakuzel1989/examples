#Sources:
#ss64.com/ps/syntax-function-input.html
#learn-powershell.net/2014/10/11/using-a-scriptblock-parameter-with-a-powershell-function/

function Print-Hello
{
    begin
    {
        Write-Host "Starting..."
    }
    
    process
    {
        Write-Host "Hello $_!"
    }
    
    end
    {
        Write-Host "Ending..."
    }
}

echo "Rachel", "Ross", "Joey", "Chandler", "Phoebe" | Print-Hello