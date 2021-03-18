# dotnet CLI

Create a SpecFlow project 

`dotnet new specflowproject --name WkspGherkin.SpecFlowProj --output WkspGherkin.SpecFlowProj`


Create a specflow.json configuration file

`dotnet new specflow-json`


Create a "Template.feature" file in Features folder
    ZX: There doesn't seems to be a way to customize output filename or its contents (its always "Template.feature")

`dotnet new specflow-feature --output Features`



## Logger options

https://github.com/Microsoft/vstest-docs/blob/master/docs/report.md

Allowed values for verbosity are:
1)  quiet
2)  minimal
3)  normal
4)  detailed

Allowed values for logger are:
1)  console
2)  trx
3)  html

### Using console as logger

Using `dotnet test` command:

`dotnet test --logger:"console;verbosity=detailed"`

`dotnet test --logger:"trx;verbosity=detailed"`

Using `vstest.console.exe` command:

`vstest.console.exe Tests.dll /logger:"console;verbosity=normal"`

### Using trx as logger

Using `dotnet test` command:

`dotnet test --logger:"trx;LogFileName=c:\temp\logFile.txt"`

Using `vstest.console.exe` command:

`vstest.console.exe Tests.dll /logger:trx`

trx file will get generated in location "c:\tempDirecory\TestResults"

`vstest.console.exe Tests.dll /logger:"trx;LogFileName=relativeDir\logFile.txt"`

trx file will be "c:\tempDirecory\TestResults\relativeDir\logFile.txt"

`vstest.console.exe Tests.dll /logger:"trx;LogFileName=c:\temp\logFile.txt"`
trx file will be "c:\temp\logFile.txt"

### Using html as logger

Using `dotnet test` command:

`dotnet test --logger:"html;LogFileName=c:\temp\logFile.html;verbosity=detailed"`

`vstest.console.exe Tests.dll /logger:html`
Html file will get generated in location "c:\tempDirecory\TestResults"

`vstest.console.exe Tests.dll /logger:"html;LogFileName=relativeDir\logFile.html"`
Html file will be "c:\tempDirecory\TestResults\relativeDir\logFile.html"

`vstest.console.exe Tests.dll /logger:"html;LogFileName=c:\temp\logFile.html"`
Html file will be "c:\temp\logFile.html"
