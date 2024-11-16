Feature: AddToCart

A short summary of the feature

@RequiresLogin
Scenario: Adding a single product to the cart
   Given the user is on the inventory page
   When the user adds "sauce-labs-bolt-t-shirt" to the cart
   Then the cart icon shows "1"

@RequiresLogin
Scenario: Adding multiple products to the cart
   Given the user is on the inventory page
   When the user adds "sauce-labs-bolt-t-shirt" to the cart
   And the user adds "sauce-labs-fleece-jacket" to the cart
   Then the cart icon shows "2"

