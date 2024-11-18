Feature: PUT request to update a product

Background:
Given the base URL is "https://fakestoreapi.com/products/"

Scenario Outline: Verifying the updated product details returned by PUT request
When I send a PUT request to update the product with the following details:
    | title   | price   | description   | image   | category   | id   |
    | <title> | <price> | <description> | <image> | <category> | <id> |
Then the request should be successful
And the response should contain the product with the following details:
    | field       | value |
    | id          | <id>  |
    | title       |       |
    | price       |       |
    | description |       |
    | image       |       |
    | category    |       |

Examples:
    | title        | price | description     | image                 | category   | id |
    | test product | 13.5  | lorem ipsum set | https://i.pravatar.cc | electronic | 7  |

Scenario: Verify behavior for an invalid endpoint
Given the base URL is "https://fakestoreapi.com/invalidEndpoint"
When I send a PUT request to update the product with the following details:
    | title   | price   | description   | image   | category   | id   |
    | <title> | <price> | <description> | <image> | <category> | <id> |
Then the request should fail
And the error message should contain "Cannot PUT"
