Feature: Customer Management

Background:
    The system needs to be able to register new customer.
    It also needs to able to update existing customer information.
    As an bank employee
	I want to register a new bank customer
	So that I can register new bank accounts for new bank customer


Scenario: Register new customer
    Given customer information "XXX|xxx,xxx"
    When customer information does not exists in system
    Then customer information is saved


Scenario: Update customer information
    Given owner information "XXX|xxx,xxx"
    When registered information is retrieved
    Then registered information is updated
