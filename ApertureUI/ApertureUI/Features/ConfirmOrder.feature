Feature: ConfirmOrder

A short summary of the feature

Scenario: Confirming the order
   Given the user is on the order summary page
   When the user clicks the confirm button
   Then the user is taken to the "Thank you" page
   And the message "Thanks for ordering" is displayed

