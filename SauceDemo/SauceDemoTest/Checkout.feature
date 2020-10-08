Feature: Checkout
	As an online customer
	I want to be able to checkout
	So that my purchase can be processed

@checkout-step-one
Scenario: No first name supplied
	Given I am on the checkout step one page
	And I enter the last name "Global"
	And I enter the postal code "SW7 5XL"
	When I click continue
	Then I see the error message "First Name is required"

@checkout-step-one
Scenario: No last name supplied
	Given I am on the checkout step one page
	And I enter the first name "Sparta"
	And I enter the postal code "SW7 5XL"
	When I click continue
	Then I see the error message "Last Name is required"

@checkout-step-one
Scenario: No postal code supplied
	Given I am on the checkout step one page
	And I enter the first name "Sparta"
	And I enter the last name "Global"
	When I click continue
	Then I see the error message "Postal Code is required"

@checkout-step-one
Scenario: All details supplied
	Given I am on the checkout step one page
	And I enter the first name "Sparta"
	And I enter the last name "Global"
	And I enter the postal code "SW7 5XL"
	When I click continue
	Then I am on the checkout step two page

@checkout-step-one
Scenario: Cancel checkout
	Given I am on the checkout step one page
	When I click cancel
	Then I am on the cart page

@checkout-step-two
Scenario: Checkout step two
	Given I have added the following items to my cart
	| item-name             |
	| Sauce Labs Backpack   |
	| Sauce Labs Bike Light |
	When I am on the checkout step two page
	Then the following items are displayed
	| item-name             |
	| Sauce Labs Backpack   |
	| Sauce Labs Bike Light |
	And the subtotal is correct

@checkout-step-two
Scenario: Complete Transaction
	Given I have added the following items to my cart
	| item-name             |
	| Sauce Labs Backpack   |
	| Sauce Labs Bike Light |
	And I am on the checkout step two page
	When I click finish
	Then I am on the checkout complete page

@checkout-step-two
Scenario: Abort Transaction
	Given I have added the following items to my cart
	| item-name             |
	| Sauce Labs Backpack   |
	| Sauce Labs Bike Light |
	And I am on the checkout step two page
	When I click cancel
	Then I am on the inventory page
	And the shopping cart displays 2