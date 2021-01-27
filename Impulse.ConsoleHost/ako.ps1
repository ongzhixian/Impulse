param (
    [string]$application = $null
)

switch ($application)
{
	########################################
	# TODO: Generic
	########################################

	"tcp-server"    { dotnet run -- settings=settings.tcp-server.json nlog=NLog.tcp-server.config }
	"tcp-client"    { dotnet run -- settings=settings.tcp-client.json nlog=NLog.tcp-client.config }

	"multicast-server"    { dotnet run -- settings=settings.multicast-server.json nlog=NLog.multicast-server.config }
	"multicast-client"    { dotnet run -- settings=settings.multicast-client.json nlog=NLog.multicast-client.config }

	"udp-server"    { dotnet run --no-build -- settings=settings.udp-server.json nlog=NLog.udp-server.config  }
	"udp-client"    { dotnet run --no-build -- settings=settings.udp-client.json nlog=NLog.udp-client.config  }

	"MoldUDP64-server"    { dotnet run -- settings=settings.MoldUDP64-server.json nlog=NLog.MoldUDP64-server.config }
	"MoldUDP64-client"    { dotnet run -- settings=settings.MoldUDP64-client.json nlog=NLog.MoldUDP64-client.config }

	#cp settings.aws-client.json settings.multicast-server.json
	#cp NLog.aws-client.config NLog.multicast-server.config 
	

	########################################
	# Implemented
	########################################

    "aws-client"    { dotnet run -- settings=settings.aws-client.json nlog=NLog.aws-client.config }
    "silo"          { dotnet run -- settings=settings.silo.json nlog=NLog.silo.config }
    "client"        { dotnet run -- settings=settings.client.json nlog=NLog.client.config }
    default         { dotnet run }
}
