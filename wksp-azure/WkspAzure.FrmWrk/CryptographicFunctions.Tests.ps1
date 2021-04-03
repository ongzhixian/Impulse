# Pester considers all files with suffix "*.Tests.ps1" to be test files.

function Post-Echo {
    # param (
    #     OptionalParameters
    # )
    $result = $null

    try {
        $url = "http://localhost:7071/api/Echo"

        $headers = @{
            "Content-Type" = "application/json"
            # Authorization="adsad"
        }

        $body = @{
            asd = "zxc"
            "message_type" = "username:password"
            "message" = @{
                "username" = "some_username"
                "password" = "some_password"
            }
        } | ConvertTo-Json

        $result = Invoke-RestMethod -Method Post -Uri $url -Headers $headers -Body $body
    }
    catch {
        throw
    }
}

Describe "WkspAzure Echo" {
    Context "Echo" {
        BeforeAll {
            $url = "http://localhost:7071/api/Echo"
            $headers = @{
                "Content-Type" = "application/json"
            }
        }

        BeforeEach {
            $url = "http://localhost:7071/api/Echo"
            Write-Host "`n[TEST START]"
        }

        It "HTTP HEAD with only queryString defined" {
            # Arrange
            $url = "$($url)?message=MessageInQueryString"

            { $result = Invoke-RestMethod -Method Head -Uri $url -Headers $headers -Body $body } 
                | Should Throw "Response status code does not indicate success: 404 (Not Found)."
        }
    }
}

Describe "WkspAzure Framework Cryptographic functions" {

    Context "Version" {
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

    Context "Echo" {
        BeforeAll {
            $url = "http://localhost:7071/api/Echo"
            $headers = @{
                "Content-Type" = "application/json"
            }
        }

        BeforeEach {
            $url = "http://localhost:7071/api/Echo"
            Write-Host "`n[TEST START]"
        }

        It "HTTP GET with no parameters defined" {
            # Arrange
            # Act
            $result = Invoke-RestMethod -Method Get -Uri $url -Headers $headers

            # Assert
            $result.httpStatusCode | Should Be 200
            $result.status | Should Be "NG"
            $result.description | Should Be "No message parameter"
        }

        It "HTTP POST with no parameters defined" {
            # Arrange
            # Act
            $result = Invoke-RestMethod -Method Post -Uri $url -Headers $headers

            # Assert
            $result.httpStatusCode | Should Be 200
            $result.status | Should Be "NG"
            $result.description | Should Be "No message parameter"
        }

        It "HTTP GET with queryString and body defined" {
            # Arrange
            $url = "$($url)?message=MessageInQueryString"
            $body = @{
                "message" = "MessageInBody"
            } | ConvertTo-Json

            # Act
            $result = Invoke-RestMethod -Method Get -Uri $url -Headers $headers -Body $body

            # Assert
            $result.httpStatusCode | Should Be 200
            $result.status | Should Be "OK"
            $result.description | Should Be "MessageInQueryString"
        }

        It "HTTP POST with queryString and body defined" {
            # Arrange
            $url = "$($url)?message=MessageInQueryString"
            $body = @{
                "message" = "MessageInBody"
            } | ConvertTo-Json

            # Act
            $result = Invoke-RestMethod -Method Post -Uri $url -Headers $headers -Body $body

            # Assert
            $result.httpStatusCode | Should Be 200
            $result.status | Should Be "OK"
            $result.description | Should Be "MessageInBody"
        }

        It "HTTP GET with only body defined" {
            # Arrange
            $body = @{
                "message" = "MessageInBody"
            } | ConvertTo-Json

            # Act
            $result = Invoke-RestMethod -Method Get -Uri $url -Headers $headers -Body $body

            # Assert
            $result.httpStatusCode | Should Be 200
            $result.status | Should Be "OK"
            $result.description | Should Be "MessageInBody"
        }

        It "HTTP POST with only body defined" {
            # Arrange
            $body = @{
                "message" = "MessageInBodyz"
            } | ConvertTo-Json

            # Act
            $result = Invoke-RestMethod -Method Post -Uri $url -Headers $headers -Body $body

            # Assert
            Write-Host $result
            $result.httpStatusCode | Should Be 200
            $result.status | Should Be "OK"
            $result.description | Should Be "MessageInBodyz"
        }

        It "HTTP GET with only queryString defined" {
            # Arrange
            $url = "$($url)?message=MessageInQueryString"

            # Act
            $result = Invoke-RestMethod -Method Get -Uri $url -Headers $headers -Body $body

            # Assert
            $result.httpStatusCode | Should Be 200
            $result.status | Should Be "OK"
            $result.description | Should Be "MessageInQueryString"
        }

        It "HTTP POST with only queryString defined" {
            # Arrange
            $url = "$($url)?message=MessageInQueryString"

            # Act
            $result = Invoke-RestMethod -Method Post -Uri $url -Headers $headers -Body $body

            # Assert
            $result.httpStatusCode | Should Be 200
            $result.status | Should Be "OK"
            $result.description | Should Be "MessageInQueryString"
        }

        It "HTTP HEAD with only queryString defined" {
            # Arrange
            $url = "$($url)?message=MessageInQueryString"

            { $result = Invoke-RestMethod -Method Head -Uri $url -Headers $headers -Body $body } 
                | Should Throw "Response status code does not indicate success: 404 (Not Found)."
        }
    }
}



Describe "RandomBytes" {

    Context "Test" {
        BeforeAll {
            $url = "http://localhost:7071/api/RandomBytes"
            $headers = @{
                "Content-Type" = "application/json"
            }
        }

        BeforeEach {
            $url = "http://localhost:7071/api/RandomBytes"
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