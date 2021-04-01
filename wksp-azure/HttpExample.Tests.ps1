# Pester considers all files with suffix "*.Tests.ps1" to be test files.

function Post-HttpExample {
    # param (
    #     OptionalParameters
    # )
    $result = $null

    try {
        $url = "http://localhost:7071/api/HttpExample"

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


Describe "HttpExample tests" {

    It "default (no parameters)" {
        # Arrange

        # Act
        #$a = Invoke-RestMethod -Method Post -Uri $url -Headers $headers -Body $body
        $a = Post-HttpExample
        Write-Host $a
        # Write-Host $a.name
        # Write-Host $a.GetType().ToString()
        
        # Asserts
        #$true | Should Be $true
        #$a.name | Should Be /api/common/utc
        
    }
}