Feature: ViewCart

@tag1
Scenario: Viewing selected products in the cart
   Given the user has added "Product A" and "Product B" to the cart
   When the user clicks the cart icon
   Then the cart page displays "Product A" and "Product B"

