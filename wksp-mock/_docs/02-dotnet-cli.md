# dotnet CLI

## WkspMock.MoqApp

dotnet new mstest --name WkspMock.MoqApp

dotnet add .\WkspMock.MoqApp\WkspMock.MoqApp.csproj package Moq

dotnet add .\WkspMock.MoqApp\WkspMock.MoqApp.csproj reference ..\wksp-idl\handcraft\WkspIdl.Handcraft.csproj

## WkspMock.RhinoMocksApp

dotnet new mstest --name WkspMock.RhinoMocksApp

dotnet add .\WkspMock.RhinoMocksApp\WkspMock.RhinoMocksApp.csproj package RhinoMocks --version 3.6.1

dotnet add .\WkspMock.RhinoMocksApp\WkspMock.RhinoMocksApp.csproj reference ..\wksp-idl\handcraft\WkspIdl.Handcraft.csproj
