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