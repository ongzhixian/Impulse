param (
    [string]$application = $null
)

switch ($application)
{
    "aws-client"    { dotnet run -- settings=settings.aws-client.json nlog=NLog.aws-client.config }
    "silo"          { dotnet run -- settings=settings.silo.json nlog=NLog.silo.config }
    "client"        { dotnet run -- settings=settings.client.json nlog=NLog.client.config }
    default         { dotnet run }
}
