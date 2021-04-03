param (
    [string]$application = $null
)

switch ($application)
{
	########################################
	# TODO: Generic
	########################################

	"local" {
        Write-Host "local tests"
        Invoke-Pester .\local_tests\
	}

    { @("prd", "prod", "production") -contains $_ } {
        Write-Host "production tests"
        Invoke-Pester .\prod_tests\RandomBytes.Tests.ps1
    }

    default { 
		Write-Host "Unsupported option $application $Args"
	}
}
