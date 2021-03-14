# 
param (
    [string]$application = $null
)

Function Build-Project {
	.\gradlew.bat build -q
}

switch ($application)
{
	########################################
	# TODO: Generic
	########################################

	# Reminder of other usage/options

	"hello" {
		.\gradlew.bat -q hello
	}

	"partner" {
		.\gradlew.bat partner
	}
	
	"demo" {
		Write-Host $Args
		.\gradlew.bat tasks $Args
	}

	# The functional stuff

	"run" {
		# echo "run"
		$a = & .\gradlew.bat run
	}

	"tasks" {
		.\gradlew.bat tasks 
	}

	"properties" {
		.\gradlew.bat properties
	}

	"all-tasks" {
		.\gradlew.bat tasks --all
	}

	{ "bld-cont", "build-continuous" } {
		.\gradlew.bat build -t
	}

	{ "bld", "build" } {
		.\gradlew.bat build
	}

    default { 
		#Write-Host "Unsupported option $application $Args"
		Write-Host "No options specified; defaulting to build" 
		Build-Project
	}
}
