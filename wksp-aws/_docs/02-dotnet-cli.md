# dotnet CLI

dotnet new sln --new WkspAws

dotnet new console --name WkspAws.ConsoleApp
dotnet sln .\WkspAws.sln add .\WkspAws.ConsoleApp\WkspAws.ConsoleApp.csproj


dotnet new classlib --name WkspAws.LambdaFunctions
dotnet add .\WkspAws.LambdaFunctions\WkspAws.LambdaFunctions.csproj package Amazon.Lambda.Core
dotnet add .\WkspAws.LambdaFunctions\WkspAws.LambdaFunctions.csproj package Amazon.Lambda.Serialization.SystemTextJson
dotnet sln .\WkspAws.sln add .\WkspAws.LambdaFunctions\WkspAws.LambdaFunctions.csproj



----

dotnet new lambda.EmptyFunction --name WkspAws.ConsoleApp

dotnet sln .\WkspAws.sln add .\WkspAws.ConsoleApp\WkspAws.ConsoleApp.csproj
dotnet sln .\WkspAws.sln add .\WkspAws.ConsoleApp.Tests\WkspAws.ConsoleApp.Tests.csproj






## Deploying Lambda function

dotnet lambda deploy-function MyFunction --function-role Lambda-Basic

## Running Lambda function

dotnet lambda invoke-function MyFunction --payload "Hello World"


## Amazon.Lambda.Templates
dotnet new -i Amazon.Lambda.Templates

## Amazon.Lambda.Tools
dotnet tool install --global Amazon.Lambda.Tools