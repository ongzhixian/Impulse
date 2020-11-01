# dotnet CLI

All commands executed from `\impulse\code`

# 2 Placeholder project

dotnet new console --name Impulse.ConsoleApplication
dotnet new mstest --name Impulse.ConsoleApplication.Tests
dotnet sln add Impulse.ConsoleApplication
dotnet sln add Impulse.ConsoleApplication.Tests
dotnet add Impulse.ConsoleApplication.Tests reference Impulse.ConsoleApplication

dotnet new console --name Impulse.ConsoleHost
dotnet new mstest --name Impulse.ConsoleHost.Tests
dotnet sln add Impulse.ConsoleHost
dotnet sln add Impulse.ConsoleHost.Tests
dotnet add Impulse.ConsoleHost.Tests reference Impulse.ConsoleHost

dotnet new classlib --name Impulse.Networking
dotnet new mstest --name Impulse.Networking.Tests
dotnet sln add Impulse.Networking
dotnet sln add Impulse.Networking.Tests
dotnet add Impulse.Networking.Tests reference Impulse.Networking

dotnet new classlib --name Impulse.Logging
dotnet new mstest --name Impulse.Logging.Tests
dotnet sln add Impulse.Logging
dotnet sln add Impulse.Logging.Tests
dotnet add Impulse.Logging.Tests reference Impulse.Logging

dotnet new classlib --name Impulse.Common
dotnet new mstest --name Impulse.Common.Tests
dotnet sln add Impulse.Common
dotnet sln add Impulse.Common.Tests
dotnet add Impulse.Common.Tests reference Impulse.Common

dotnet new classlib --name Impulse.Applications
dotnet new mstest --name Impulse.Applications.Tests
dotnet sln add Impulse.Applications
dotnet sln add Impulse.Applications.Tests
dotnet add Impulse.Applications.Tests reference Impulse.Applications

dotnet new classlib --name Impulse.Web
dotnet new mstest --name Impulse.Web.Tests
dotnet sln add Impulse.Web
dotnet sln add Impulse.Web.Tests
dotnet add Impulse.Web.Tests reference Impulse.Web

dotnet new classlib --name Impulse.AspNetCoreReplica
dotnet sln add Impulse.AspNetCoreReplica


dotnet new web --name Impulse.AspNetCoreHost
dotnet new mstest --name Impulse.AspNetCoreHost.Tests
dotnet sln add Impulse.AspNetCoreHost
dotnet sln add Impulse.AspNetCoreHost.Tests
dotnet add Impulse.AspNetCoreHost.Tests reference Impulse.AspNetCoreHost


dotnet new mvc --name Impulse.AspNetCoreMvcHost
dotnet new mstest --name Impulse.AspNetCoreMvcHost.Tests
dotnet sln add Impulse.AspNetCoreMvcHost
dotnet sln add Impulse.AspNetCoreMvcHost.Tests
dotnet add Impulse.AspNetCoreMvcHost.Tests reference Impulse.AspNetCoreMvcHost


dotnet new webapi --name Impulse.WebApiHost
dotnet new mstest --name Impulse.WebApiHost.Tests
dotnet sln add Impulse.WebApiHost
dotnet sln add Impulse.WebApiHost.Tests
dotnet add Impulse.WebApiHost.Tests reference Impulse.WebApiHost



dotnet new razorclasslib --name Impulse.CommonWebApiRazor
dotnet new mstest --name Impulse.CommonWebApiRazor.Tests
dotnet sln add Impulse.CommonWebApiRazor
dotnet sln add Impulse.CommonWebApiRazor.Tests
dotnet add Impulse.CommonWebApiRazor.Tests reference Impulse.CommonWebApiRazor



dotnet new webapi --name Impulse.DummyWebApiHost
dotnet sln add Impulse.DummyWebApiHost



# 1 Create global.json 
dotnet new globaljson --sdk-version 2.1.518
dotnet new sln --name Impulse