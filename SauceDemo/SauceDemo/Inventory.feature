Feature: Inventory
	As an online shopper
	I want to be able to view details of products
	So that I can know more about them

@inventory
Scenario: Click on a link to view product details
	Given I am on the inventory page
	When I click on a link for item with id <id>
	Then I am taken to a page showing me the details of the item with id <id>

	Examples:
	| id |
	| 0  |
	| 1  |
	| 2  |
	| 3  |
	| 4  |
	| 5  |