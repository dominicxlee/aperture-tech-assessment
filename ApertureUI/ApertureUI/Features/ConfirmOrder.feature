Feature: ConfirmOrder

A short summary of the feature

@RequiresLogin
Scenario: Confirming the order
   Given the user has added the following products to the cart:
     | Product Name               |
     | sauce-labs-bolt-t-shirt    |
     | sauce-labs-fleece-jacket   |
   When the user views the cart
   And proceeds to checkout
   And fills out the checkout form with the following details:
     | First Name | Last Name | Postal Code |
     | John       | Doe       | 12345       |
   And confirms the order
   Then the order summary page is displayed
   And the following products are listed in the summary:
     | Product Name               |
     | sauce-labs-bolt-t-shirt    |
     | sauce-labs-fleece-jacket   |


