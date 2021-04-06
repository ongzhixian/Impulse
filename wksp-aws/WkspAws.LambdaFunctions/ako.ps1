# Deployment

#aws s3api create-bucket --bucket wksp-aws-lambda-functions --region us-east-1

aws s3 mb s3://wksp-aws-lambda-functions --region us-east-1

dotnet lambda deploy-serverless WkspAwsLambdaFunctions --s3-bucket wksp-aws-lambda-functions


#aws s3api delete-bucket --bucket wksp-aws-lambda-functions --region us-east-1

## Emptying bucket
# aws s3 rm s3://wksp-aws-lambda-functions --recursive
aws s3 rb s3://wksp-aws-lambda-functions --force