param (
    [string]$application = $null
)

Function Build-CoverageSnapshot {
	dotcover dotnet .\code-coverage\Impulse.Common.Tests.xml
}

switch ($application)
{
	########################################
	# TODO: Generic
	########################################

	"cover" { 
		Write-Host "Code coverage using dotCover"

		# This is for .net Framework
		#dotcover cover .\code-coverage\Impulse.Common.Tests.xml

		# This is for .NET Core
		Build-CoverageSnapshot

	}

	"merge" {
		dotcover merge .\code-coverage\_merge.xml
	}

	"report" {
		dotcover report .\code-coverage\_report.xml
	}

	"all" {
		Build-CoverageSnapshot
		dotcover merge .\code-coverage\_merge.xml
		dotcover report .\code-coverage\_report.xml
	}

    default { 
		Write-Host "Unsupported option $application $Args"
	}
}
