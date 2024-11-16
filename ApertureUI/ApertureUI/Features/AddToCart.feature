Feature: AddToCart

A short summary of the feature

Scenario: Adding a single product to the cart
   Given the user is on the inventory page
   When the user adds "Product A" to the cart
   Then the cart icon shows "1"

Scenario: Adding multiple products to the cart
   Given the user is on the inventory page
   When the user adds "Product A" and "Product B" to the cart
   Then the cart icon shows "2"

