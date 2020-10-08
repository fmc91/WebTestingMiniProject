Feature: Login
	As a website user
	I want to be able to login to the website
	So that I can use the full feature set of the website

@login
Scenario: Username not recognised
	Given I am on the home page
	And I enter the username "unrecognised_user"
	And I enter the password "password"
	When I click the login button
	Then I should see the error message "Username and password do not match any user in this service"

@login
Scenario: Incorrect password
	Given I am on the home page
	And I enter the username "standard_user"
	And I enter the password "incorrect_password"
	When I click the login button
	Then I should see the error message "Username and password do not match any user in this service"

@login
Scenario: Blank username
	Given I am on the home page
	And I enter the password "password"
	When I click the login button
	Then I should see the error message "Username is required"

@login
Scenario: Blank password
	Given I am on the home page
	And I enter the username "username"
	When I click the login button
	Then I should see the error message "Password is required"

@login
Scenario: Locked out user
	Given I am on the home page
	And I enter the username "locked_out_user"
	And I enter the password "secret_sauce"
	When I click the login button
	Then I should see the error message "Sorry, this user has been locked out"

@login
Scenario: Correct username and password
	Given I am on the home page
	And I enter the username "standard_user"
	And I enter the password "secret_sauce"
	When I click the login button
	Then I am on the inventory page