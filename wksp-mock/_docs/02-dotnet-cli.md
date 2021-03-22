# dotnet CLI

dotnet new mstest --name WkspMock.MoqApp

dotnet add .\WkspMock.MoqApp\WkspMock.MoqApp.csproj package Moq

dotnet add .\WkspMock.MoqApp\WkspMock.MoqApp.csproj reference ..\wksp-idl\handcraft\WkspIdl.Handcraft.csproj