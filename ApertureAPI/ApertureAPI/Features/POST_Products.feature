Feature: Create a New Product

  Scenario Outline: Verify that a new product is created successfully with the provided data
    Given the base URL is "https://fakestoreapi.com/products"
    When I send a POST request with the following product data:
      | title        | price   | description     | image            | category   |
      | <title>      | <price> | <description>   | <image>          | <category> |
    Then the response code should be 200

    Examples:
      | title         | price | description       | image                 | category   |
      | test product  | 13.5  | lorem ipsum set   | https://i.pravatar.cc | electronic |
        