Describe "Version (as Managed API)" {

    Context "Managed API" {
        BeforeAll {
            $url = "https://telara-api-management.azure-api.net/WkspAzureFrmWrk/Version"
            $headers = @{
                "Content-Type" = "application/json"
            }
        }

        BeforeEach {
            $url = "https://telara-api-management.azure-api.net/WkspAzureFrmWrk/Version"
            Write-Host "`n[TEST START]"
        }

        It "Scenario 1: Default scenario" {
            # Act
            $result = Invoke-RestMethod -Method Get -Uri $url -Headers $headers

            # Assert
            Write-Host $result
            Write-Host $result.status
        }
    }
}
