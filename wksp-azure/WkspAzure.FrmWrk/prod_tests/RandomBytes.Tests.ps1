Describe "RandomBytes" {

    Context "Test" {
        BeforeAll {
            $url = "https://wkspazurefrmwrk.azurewebsites.net/api/RandomBytes"
            $headers = @{
                "Content-Type" = "application/json"
            }
        }

        BeforeEach {
            $url = "https://wkspazurefrmwrk.azurewebsites.net/api/RandomBytes"
            Write-Host "`n[TEST START]"
        }

        It "Scenario 1: Using query string" {
            # Arrange
            $url = "$($url)?numberOfBytes=16"

            # Act
            $result = Invoke-RestMethod -Method Get -Uri $url -Headers $headers

            # Assert
            [Convert]::FromBase64String($result.bytesInBase64).Length | Should Be 16
        }

        It "Scenario 2: Using body" {
            # Arrange
            $body = @{
                "numberOfBytes" = 32
            } | ConvertTo-Json

            # Act
            $result = Invoke-RestMethod -Method Post -Uri $url -Headers $headers -Body $body

            # Assert
            [Convert]::FromBase64String($result.bytesInBase64).Length | Should Be 32
        }
    }

}