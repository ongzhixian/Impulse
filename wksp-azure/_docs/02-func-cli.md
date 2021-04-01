# Azure func CLI

## Create project

func init TelaraFunctions --dotnet

## Add functions

func new --name Echo --template "HTTP trigger" --authlevel "anonymous"
func new --name EpochTime --template "HTTP trigger" --authlevel "anonymous"

## Run functions in project

func start