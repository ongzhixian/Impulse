Describe "Versopm" {

    Context "Test" {
        BeforeAll {
            $url = "http://localhost:7071/api/Version"
            $headers = @{
                "Content-Type" = "application/json"
            }
        }

        BeforeEach {
            $url = "http://localhost:7071/api/Version"
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
