Feature: Checkout

A short summary of the feature

Scenario: Filling out checkout details
   Given the user is on the checkout page
   When the user enters "John" as the first name
   And "Doe" as the last name
   And "12345" as the postal code
   And clicks the continue button
   Then the user is taken to the order summary page

