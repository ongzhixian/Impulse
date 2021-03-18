Feature: Calculator
    In order to make it easier on my brain
    As someone who is not good at mental arithmetic
    I want to use the computer to do basic maths

Scenario: Add two numbers
    Given The calculator is reset 	
    When I enter 40
    And I Add 20
    Then The value should be 60
