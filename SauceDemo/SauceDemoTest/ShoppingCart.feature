Feature: ShoppingCart
	As an online shopper
	I want to be able to add items I want to purchase to a virtual cart
	So that when I checkout, I can pay for them all in one transaction

@shopping-cart
Scenario: Add items to cart
	Given I am on the inventory page
	When I add <n> items to my cart
	Then the shopping cart displays <n>

	Examples:
	| n |
	| 1 |
	| 2 |
	| 3 |
	| 4 |
	| 5 |
	| 6 |

@shopping-cart
Scenario: Remove item from cart
	Given I am on the inventory page
	When I add <before> items to my cart
	And I remove item 1 from my cart
	Then the shopping cart displays <after>
	And the inventory button for item 1 displays "ADD TO CART"

	Examples:
	| before | after |
	| 2      | 1     |
	| 3      | 2     |
	| 4      | 3     |
	| 5      | 4     |
	| 6      | 5     |

@shopping-cart
Scenario: Change text on inventory button
	Given I am on the inventory page
	When I add item <n> to my cart
	Then the inventory button for item <n> displays "REMOVE"

	Examples:
	| n |
	| 1 |
	| 2 |
	| 3 |
	| 4 |
	| 5 |
	| 6 |

@shopping-cart
Scenario: Correct items are in the cart
	Given I am on the inventory page
	And I add the item called <name> to my cart
	When I click on the shopping cart
	Then I am on the cart page
	And the item called <name> is in my cart

	Examples:
	| name                |
	| Sauce Labs Backpack |

@shopping-cart
Scenario: Removing items from cart page
	Given I have added the item called <name> to my cart
	And I am on the cart page
	When I remove the item called <name> from my cart
	Then The item called <name> is not in my cart

	Examples:
	| name                |
	| Sauce Labs Backpack |

@shopping-cart
Scenario: Click checkout
	Given I am on the cart page
	When I click checkout
	Then I am on the checkout step one page