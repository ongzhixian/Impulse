Feature: Account Management

Background:
    The system needs to register new account.
    It also needs to update account information.


Scenario: Register new account
    Given customer information "XXX|xxx,xxx"
        And account information "xxx"
    When account information does not exists in system
    Then account information is saved into system


Scenario: Update account information
    Given account information "XXX|xxx,xxx"
    When registered information is retrieved
        And registered information is updated
    Then account information is saved into system
