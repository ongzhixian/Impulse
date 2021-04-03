Feature: GetRandomBytes
	Given number of bytes as input return a random number of bytes equivalent to input

@mytag
Scenario: Return 16 random bytes
	Given user input of number of bytes is 16
	When GetRandomBytes is executed
	Then I should get byte array that is 16 bytes long