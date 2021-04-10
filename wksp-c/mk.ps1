param (
    [string]$application = $null
)

# Function Build-CoverageSnapshot {
# 	dotcover dotnet .\code-coverage\Impulse.Common.Tests.xml
# }

$CFLAGS = "-Wall -pedantic"

switch ($application)
{
	########################################
	# TODO: Generic
	########################################

    "hello" {
        Invoke-Expression "gcc hello.c $CFLAGS -o hello"
    }

    "main" {
        Invoke-Expression "gcc main.c -Wall -pedantic -o ako -lws2_32"
    }

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

    default { 
		Write-Host "Unsupported option $application $Args"
	}
}
