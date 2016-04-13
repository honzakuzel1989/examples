function Print-Hello
{
    param 
    (
        [parameter(Mandatory, ValueFromPipelineByPropertyName)]
        [string] $Name
    )

    begin
    {
        Write-Host "Starting..."
    }
    
    process
    {
        Write-Host "Hello $_ ($Name)!"
    }
    
    end
    {
        Write-Host "Ending..."
    }
}

echo "Rachel", "Ross", "Joey", "Chandler", "Phoebe" | Print-Hello -Name { $_.ToLower() }