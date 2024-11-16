Feature: ViewCart

@RequiresLogin
Scenario: Viewing selected products in the cart
   Given the user has added "sauce-labs-bolt-t-shirt" to the cart
   And the user has added "sauce-labs-fleece-jacket" to the cart
   When the user clicks the cart icon
   Then the cart page displays "sauce-labs-bolt-t-shirt"
   And the cart page displays "sauce-labs-fleece-jacket"

