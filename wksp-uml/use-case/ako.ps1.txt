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


	"seq" {
		# Working
        # java -jar plantuml.jar -verbose sequenceDiagram.txt
        java -jar C:\Apps\bin\plantuml.jar sample-sequence.uml
	}

    default {
        if (Test-Path $application)
		{
            java -jar C:\Apps\bin\plantuml.jar $application
			Write-Host "Done on $($(Get-Date).ToString("u"))"
			return
		}
		Write-Host "Unsupported option $application $Args"
	}
}