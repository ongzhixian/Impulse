Describe "Version (as Function App)" {

    Context "Function App" {
        BeforeAll {
            $url = "https://wkspazurefrmwrk.azurewebsites.net/api/Version"
            $headers = @{
                "Content-Type" = "application/json"
            }
        }

        BeforeEach {
            $url = "https://wkspazurefrmwrk.azurewebsites.net/api/Version"
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
