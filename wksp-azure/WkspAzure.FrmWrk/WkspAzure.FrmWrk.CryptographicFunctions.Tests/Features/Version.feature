@AzureFunction
Feature: Version
	Azure function to get version number

Scenario: Get version number
	Given version request message
	When version function is executed
	Then result should be a response message with version number
