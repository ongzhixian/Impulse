# dotnet CLI

## Install templates

dotnet new -i Google.Cloud.Functions.Templates::1.0.0-beta04

## Create globaljson

dotnet new globaljson

## Create solution

dotnet new sln --name WkspGcpEmptool

## Add projects

dotnet new mvc --name WkspGcpEmptool.TechNotesWeb
dotnet sln .\WkspGcpEmptool.sln add .\WkspGcpEmptool.TechNotesWeb\WkspGcpEmptool.TechNotesWeb.csproj


dotnet new console --name WkspGcpEmptool.CloudFunctions
dotnet add .\WkspGcpEmptool.CloudFunctions\WkspGcpEmptool.CloudFunctions.csproj package Google.Cloud.Functions.Hosting --version 1.0.0-beta04
dotnet sln .\WkspGcpEmptool.sln add .\WkspGcpEmptool.CloudFunctions\WkspGcpEmptool.CloudFunctions.csproj