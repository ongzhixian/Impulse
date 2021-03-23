# Build interface library
dotnet build ..\wksp-idl\handcraft\

# Build mocks
dotnet build .\WkspMock.MoqApp\
#dotnet build .\WkspMock.RhinoMocksApp\

dotnet test .\WkspMock.MoqApp\