Feature: Create a New Product

Scenario Outline: Verify that a new product is created successfully with the provided data
Given the base URL is "https://fakestoreapi.com/products"
When I send a POST request with the following product data:
    | title        | price   | description     | image            | category   |
    | <title>      | <price> | <description>   | <image>          | <category> |
Then the request should be successful
And the response should contain the product with the following details:
    | field       | value |
    | title       |       |
    | price       |       |
    | description |       |
    | image       |       |
    | category    |       |

Examples:
    | title         | price | description       | image                 | category   |
    | test product  | 13.5  | lorem ipsum set   | https://i.pravatar.cc | electronic |
        

Scenario: Verify behavior for an invalid endpoint
Given the base URL is "https://fakestoreapi.com/invalidEndpoint"
When I send a POST request with the following product data:
    | title        | price   | description     | image            | category   |
    | <title>      | <price> | <description>   | <image>          | <category> |
Then the request should fail
And the error message should contain "Cannot POST"