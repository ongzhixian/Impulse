## S3

function Get-S3Buckets {
    # param (
    #     [Parameter(Mandatory)]
    #     [string] $GroupName
    # )
    (aws s3api list-buckets | ConvertFrom-Json).Buckets
}


function New-S3Bucket {
    param (
        [Parameter(Mandatory)]
        [string] $Name,
        [string] $Region="us-east-1"
    )
    aws s3api create-bucket --bucket $Name --region $Region
}

function Remove-S3Bucket {
    param (
        [Parameter(Mandatory)]
        [string] $Name
        
    )
    aws s3api delete-bucket --bucket $Name
}