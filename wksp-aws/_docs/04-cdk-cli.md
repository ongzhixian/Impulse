# CDK CLI

## Install CDK

npm install -g aws-cdk



## Workshop

```
mkdir cdk-workshop && cd cdk-workshop
cdk init sample-app --language csharp
```

``` Results
PS> cdk init sample-app --language csharp
Applying project template sample-app for csharp
Project `CdkWorkshop\CdkWorkshop.csproj` added to the solution.
# Welcome to your CDK C# project!

You should explore the contents of this project. It demonstrates a CDK app with an instance of a stack (`CdkWorkshopStack`)
which contains an Amazon SQS queue that is subscribed to an Amazon SNS topic.

The `cdk.json` file tells the CDK Toolkit how to execute your app.

It uses the [.NET Core CLI](https://docs.microsoft.com/dotnet/articles/core/) to compile and execute your project.

## Useful commands

* `dotnet build src` compile this app
* `cdk ls`           list all stacks in the app
* `cdk synth`       emits the synthesized CloudFormation template
* `cdk deploy`      deploy this stack to your default AWS account/region
* `cdk diff`        compare deployed stack with current state
* `cdk docs`        open CDK documentation

Enjoy!

✅ All done!
```

## Packages to add to .NET .csproj


dotnet add package Amazon.CDK.AWS.Lambda
dotnet add package Amazon.CDK.AWS.APIGateway
