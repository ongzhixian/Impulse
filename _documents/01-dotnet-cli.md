# dotnet CLI

All commands executed from `\impulse\code`

# 2 Placeholder project

dotnet new console --name Impulse.ConsoleApplications.FirstConsole
dotnet new mstest --name Impulse.ConsoleApplications.FirstConsole.Tests
dotnet sln add Impulse.ConsoleApplications.FirstConsole
dotnet sln add Impulse.ConsoleApplications.FirstConsole.Tests
dotnet add Impulse.ConsoleApplications.FirstConsole.Tests reference Impulse.ConsoleApplications.FirstConsole

dotnet new classlib --name Impulse.Logging
dotnet new mstest --name Impulse.Logging.Tests
dotnet sln add Impulse.Logging
dotnet sln add Impulse.Logging.Tests
dotnet add Impulse.Logging.Tests reference Impulse.Logging


# 1 Create global.json 
dotnet new globaljson --sdk-version 2.1.518
dotnet new sln --name Impulse