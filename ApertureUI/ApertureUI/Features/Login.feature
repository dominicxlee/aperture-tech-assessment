Feature: Login

Allows a user to enter username and password to login

@mytag
Scenario: successful login
	Given the username is "standard_user"
	And the password is "secret_sauce"
	When the login button is pressed
	Then the user is logged in

Scenario: unsuccessful login
	Given the username is "random"
	And the password is "random_again"
	When the login button is pressed
	Then the user is not logged in