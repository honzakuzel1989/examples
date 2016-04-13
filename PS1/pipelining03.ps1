function Print-Hello
{
    param 
    (
        [scriptblock] $Command = $null
    )

    begin
    {
        Write-Host "Starting..."
    }
    
    process
    {
        Write-Host "Processing $_..."
        if($Command) { Invoke-Command $Command }
        else { Write-Host "Hello $_!" }
    }
    
    end
    {
        Write-Host "Ending..."
    }
}

echo "#1"
echo "Rachel", "Ross", "Joey", "Chandler", "Phoebe" | Print-Hello

echo ""
echo "#2"
echo "Rachel", "Ross", "Joey", "Chandler", "Phoebe" | Print-Hello -Command { 
    if($_.StartsWith('R')) { Write-Host $_ -Foreground green }
    else { Write-Host $_ -Foreground red }
}