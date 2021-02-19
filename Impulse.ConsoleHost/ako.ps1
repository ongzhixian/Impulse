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

	"multicast-sender"    { dotnet run -- settings=settings.multicast-sender.json nlog=NLog.multicast-sender.config }
	"multicast-receiver"    { dotnet run -- settings=settings.multicast-receiver.json nlog=NLog.multicast-receiver.config }

	"udp-server"    { dotnet run --no-build -- settings=settings.udp-server.json nlog=NLog.udp-server.config log4net=log4net.udp-server.config  }
	"udp-client"    { dotnet run --no-build -- settings=settings.udp-client.json nlog=NLog.udp-client.config  }

	"MoldUDP64-server"    { dotnet run -- settings=settings.MoldUDP64-server.json nlog=NLog.MoldUDP64-server.config }
	"MoldUDP64-client"    { dotnet run -- settings=settings.MoldUDP64-client.json nlog=NLog.MoldUDP64-client.config }

	#cp settings.aws-client.json settings.multicast-server.json
	#cp NLog.aws-client.config NLog.multicast-server.config 

	########################################
	# Windows Service install/uninstall
	########################################

	"install-service" {
		# PowerShell script to install Windows Service (requires administrator)

		# Snippet to check if running script under Administrator account
		# $currentPrincipal = New-Object Security.Principal.WindowsPrincipal([Security.Principal.WindowsIdentity]::GetCurrent())
		# $currentPrincipal.IsInRole([Security.Principal.WindowsBuiltInRole]::Administrator)

		# $APP_PATH     = {EXE PATH}        – Path to the app's folder on the host (for example, d:\myservice). Don't include the app's executable in the path. A trailing slash isn't required.
		# $ACCOUNT_NAME = {DOMAIN OR COMPUTER NAME\USER} – Service user account (for example, Contoso\ServiceUser).
		# $EXE_PATH     = {EXE FILE PATH}   – The app's executable path (for example, d:\myservice\myservice.exe). Include the executable's file name with extension.
		# $SVC_NAME     = {SERVICE NAME}    – Service name (for example, MyService).
		# $SVC_DISP     = {DISPLAY NAME}    – Service display name (for example, My Service).
		# $SVC_DESC     = {DESCRIPTION}     – Service description (for example, My sample service).

		$APP_PATH       = "C:\src\ostagar\DemoRabbitMQ\Pgg.WindowsServiceWorker\bin\Debug\netcoreapp2.2\win7-x64"
		$ACCOUNT_NAME   = "SG00-L4579\PggWindowsService"
		$EXE_PATH       = "C:\src\ostagar\DemoRabbitMQ\Pgg.WindowsServiceWorker\bin\Debug\netcoreapp2.2\win7-x64\Pgg.WindowsServiceWorker.exe"
		$SVC_NAME       = "PggWindowsServiceHosted"
		$SVC_DISP       = "Pgg Windows Service Hosted"
		$SVC_DESC       = "Pgg .NET Core hosted on Windows Service"

		$acl            = Get-Acl $APP_PATH
		$aclRuleArgs    = $ACCOUNT_NAME, "Read, Write, ReadAndExecute", "ContainerInherit, ObjectInherit", "None", "Allow"
		$accessRule     = New-Object System.Security.AccessControl.FileSystemAccessRule($aclRuleArgs)
		$acl.SetAccessRule($accessRule)
		$acl | Set-Acl $APP_PATH

		New-Service -Name $SVC_NAME -DisplayName $SVC_DISP -BinaryPathName $EXE_PATH -Credential $ACCOUNT_NAME -Description $SVC_DESC -StartupType Automatic
	}

	"uninstall-service" {
		# PowerShell script to uninstall Windows Service (requires administrator)

		$SVC_NAME = "PggWindowsServiceHosted"

		(Get-WmiObject -Class Win32_Service -Filter "Name='$SVC_NAME'").Delete()

		# The more verbose form
		# $service = Get-WmiObject -Class Win32_Service -Filter "Name='PggWindowsService'"
		# $service.delete()
	
	}

	########################################
	# Implemented
	########################################

    "aws-client"    { dotnet run -- settings=settings.aws-client.json nlog=NLog.aws-client.config }
    "silo"          { dotnet run -- settings=settings.silo.json nlog=NLog.silo.config }
    "client"        { dotnet run -- settings=settings.client.json nlog=NLog.client.config }
    default         { dotnet run }
}
