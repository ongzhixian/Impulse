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


Describe "Example Pester Test Suite" {

    # BeforeAll {
    #     # This block runs before any tests have ran 
    #     Write-Host "BeforeAll start $((Get-Date).ToString("u"))"
    # }

    # BeforeEach {
    #     # This block runs before each test have ran 
    #     Write-Host "Test start $((Get-Date).ToString("u"))"
    # }

    # AfterEach {
    #     # This block runs after each test have ran 
    #     Write-Host "Test end $((Get-Date).ToString("u"))"
    # }

    # AfterAll {
    #     # This block runs after all tests have ran 
    #     Write-Host "AfterAll ends $((Get-Date).ToString("u"))"
    # }

    It "Sample test 1 $((Get-Date).ToString("u"))" {
        $true | Should Be $true
        
    }

    It "Sample test 2 $((Get-Date).ToString("u"))" {
        #Should -Be $true
        $true | Should Be $true
    }

    Context "HTTP Post" {
        It "default (no parameters)" {
            # Arrange
    
            # Act
            # $a = Invoke-RestMethod -Method Post -Uri $url -Headers $headers -Body $body
            # Write-Host $a
            # Write-Host $a.name
            # Write-Host $a.GetType().ToString()
            
            # Asserts
            #$true | Should Be $true
            #$a.name | Should Be /api/common/utc
        }
    }

    Context "HTTP Get" {
        It "default (no parameters)" {
            # Arrange
    
            # Act
            # $a = Invoke-RestMethod -Method Get -Uri $url -Headers $headers -Body $body
            # Write-Host $a
            # Write-Host $a.name
            # Write-Host $a.GetType().ToString()
            
            # Asserts
            #$true | Should Be $true
            #$a.name | Should Be /api/common/utc
        }
    }


}