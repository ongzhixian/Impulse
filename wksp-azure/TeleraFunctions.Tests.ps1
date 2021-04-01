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


Describe "Telera functions" {

    Context "Echo" {

        BeforeAll {
            $url = "http://localhost:7071/api/Echo"
            $headers = @{
                "Content-Type" = "application/json"
            }
            $body = @{
                asd = "zxc"
                "message_type" = "username:password"
                "message" = @{
                    "username" = "some_username"
                    "password" = "some_password"
                }
            } | ConvertTo-Json
        }

        BeforeEach {
            $url = "http://localhost:7071/api/Echo"
            Write-Host "`n[TEST START]"
        }

        It "HTTP GET ?message=helloworld" {
            # Arrange
            $url = "$($url)?message=helloworld"
            
            # Act
            $result = Invoke-RestMethod -Method Get -Uri $url -Headers $headers

            # Assert
            Write-Host "GET result" $result 
            
        }

        It "HTTP POST" {
            # Arrange
            #$url = "$($url)" 
            $body = @{
                "message" = "HTTP POST DEMO"
            } | ConvertTo-Json
            
            # Act
            $result = Invoke-RestMethod -Method Get -Uri $url -Headers $headers -Body $body

            # Assert
            Write-Host $result
        }
    }


}