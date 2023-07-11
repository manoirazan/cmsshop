Feature: Shop
Background: 
	Given I am on the shop home page

Scenario: Add some items to cart
	Given I add four random items to my cart
	When I view my cart
	Then I find total four items listed in my cart	
	When I remove the lowest price item from my cart
	Then I am able to verify three items in my cart