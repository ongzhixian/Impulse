param (
    [string]$application = $null
)

# Function Build-CoverageSnapshot {
# 	dotcover dotnet .\code-coverage\Impulse.Common.Tests.xml
# }


switch ($application)
{
	########################################
	# TODO: Generic
	########################################

	# "cover" { 
	# 	Write-Host "Code coverage using dotCover"

	# 	# This is for .net Framework
	# 	#dotcover cover .\code-coverage\Impulse.Common.Tests.xml

	# 	# This is for .NET Core
	# 	Build-CoverageSnapshot

	# }

	# "merge" {
	# 	dotcover merge .\code-coverage\_merge.xml
	# }

	# "report" {
	# 	dotcover report .\code-coverage\_report.xml
	# }

	# "all" {
	# 	Build-CoverageSnapshot
	# 	dotcover merge .\code-coverage\_merge.xml
	# 	dotcover report .\code-coverage\_report.xml
	# }

	"deploy" {
		gcloud functions deploy HelloWorldFunction --entry-point WkspGcpEmptool.CloudFunctions.HelloWorld --runtime dotnet3 --trigger-http --allow-unauthenticated
		#gcloud functions describe HelloWorldFunction
	}


    "setup" {
        Write-Host "[START SETUP]"
        $env:GOOGLE_APPLICATION_CREDENTIALS = "$env:USERPROFILE\Documents\PowerShell\emptool-com-057076f42f63.json"
        Write-Host "[END SETUP]"
    }

    default { 
		Write-Host "Unsupported option $application $Args"
	}
}
