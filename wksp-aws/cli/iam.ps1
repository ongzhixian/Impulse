## IAM Groups

function New-IAMGroup {
    param (
        [Parameter(Mandatory)]
        [string] $GroupName
    )
    aws iam create-group --group-name $GroupName
}


function Get-IAMGroups {
    # param (
    #     OptionalParameters
    # )
    (aws iam list-groups | ConvertFrom-Json).Groups
}

function Add-ToIAMGroup {
    param (
        [Parameter(Mandatory)]
        [string] $GroupName,
        [Parameter(Mandatory)]
        [string] $UserName
    )
    aws iam add-user-to-group --group-name $GroupName --user-name $UserName
}


## IAM Policies

function Get-IAMPolicies {
    param (
        [ValidateSet("All", "AWS", "Local")]
        [string]$ScopeType="All"
    )
    (aws iam list-policies --scope $ScopeType | ConvertFrom-Json).Policies
}

function Remove-IAMPolicy {
    param (
        [Parameter(Mandatory)]
        [string] $Arn
    )
    aws iam delete-policy --policy-arn $Arn
}

## IAM Users

function Get-IAMUsers {
    # param (
    #     OptionalParameters
    # )
    (aws iam list-users | ConvertFrom-Json).Users
}


## IAM Roles

function Get-IAMRoles {
    # param (
    #     OptionalParameters
    # )
    (aws iam list-roles | ConvertFrom-Json).Roles
}
