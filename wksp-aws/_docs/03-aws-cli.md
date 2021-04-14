# aws CLI


## AWS Credentials can be found in the following location:

    ~/.aws/credentials (Linux & Mac) 
    or
    %USERPROFILE%\.aws\credentials (Windows)

    C:\Users\zhixian\.aws\credentials

## Using profile

Per command-by-command

`aws ec2 describe-instances --profile user1`

`setx AWS_PROFILE user1`

```
setx AWS_ACCESS_KEY_ID AKIAIOSFODNN7EXAMPLE
setx AWS_SECRET_ACCESS_KEY wJalrXUtnFEMI/K7MDENG/bPxRfiCYEXAMPLEKEY
setx AWS_DEFAULT_REGION us-west-2
```

```
$Env:AWS_ACCESS_KEY_ID="AKIAQEITOFC3TMJ3CDMB"
$Env:AWS_SECRET_ACCESS_KEY="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"
$Env:AWS_DEFAULT_REGION="us-east-1"
```


# Reference

Environment variables to configure the AWS CLI
https://docs.aws.amazon.com/cli/latest/userguide/cli-configure-envvars.html