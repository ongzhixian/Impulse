# dotnet CLI

All commands executed from `\impulse\code`

# 2 Placeholder project

dotnet new console --name Impulse.ConsoleApplication
dotnet new mstest --name Impulse.ConsoleApplication.Tests
dotnet sln add Impulse.ConsoleApplication
dotnet sln add Impulse.ConsoleApplication.Tests
dotnet add Impulse.ConsoleApplication.Tests reference Impulse.ConsoleApplication

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

# 1 Create global.json 
dotnet new globaljson --sdk-version 2.1.518
dotnet new sln --name Impulse