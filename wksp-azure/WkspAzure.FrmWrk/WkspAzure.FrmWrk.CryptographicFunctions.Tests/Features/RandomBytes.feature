@AzureFunction
Feature: RandomBytes
	Return random number of bytes

Scenario: Get 16 random bytes
	Given input of 16
	When randomBytes function is executed
	Then result should be a response message with 16 random bytes