dotnet build
if ($LASTEXITCODE -ne 0)
{
    exit
}

dotnet run --project .\Impulse.ConsoleApplication\