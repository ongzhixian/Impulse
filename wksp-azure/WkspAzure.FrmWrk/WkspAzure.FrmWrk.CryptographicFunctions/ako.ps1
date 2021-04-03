param (
    [string]$application = $null
)

switch ($application)
{
	########################################
	# TODO: Generic
	########################################

	"verbose" {
        func start --csharp --verbose
	}

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

    "build" {
        Write-Host "build"
        dotnet build
    }

    "run" {
        Write-Host "run"
        func start --csharp
    }

    "test" {
        Write-Host "Test"
    }

    { @("deploy", "pub", "publish") -contains $_ } {
        Write-Host "Deploy"
        # Compile in Release configuration and publish
        dotnet publish -c Release

        # Zipped published content
        $publishFolder = Join-Path $PWD "bin/Release/net472/publish"
        $publishZipFilePath = Join-Path $PWD "publish.zip"
        [System.IO.Compression.ZipFile]::CreateFromDirectory($publishFolder, $publishZipFilePath)
        
        # deploy the zipped package
        $resourceGroup = "telera-resource-group"
        $functionAppName = "WkspAzureFrmWrk"
        az functionapp deployment source config-zip -g $resourceGroup -n $functionAppName --src $publishZipFilePath

        # Notes
        # App Name:     WkspAzureFrmWrk
        # Hosting Plan: WkspAzureFrmWrkHostingPlan
        # https://wkspazurefrmwrk.azurewebsites.net
    }

    default { 
		Write-Host "Unsupported option $application $Args"
	}
}
