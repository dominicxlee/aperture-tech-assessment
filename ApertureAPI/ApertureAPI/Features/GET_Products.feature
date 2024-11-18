Feature: GET Products

Background:
Given the base URL is "https://fakestoreapi.com/products"

Scenario: Verify that the API returns a valid response
When I send a GET request to the endpoint
Then the request should be successful
And the response should contain a list of products

Scenario Outline: Verify product structure in the response
When I send a GET request to the endpoint
Then the response should contain a product with id <id>
And the product should have a title
And the product should have a price
And the product should have a category
And the product should have a description

Examples:
    | id  |
    | 1   |
    | 5   |
    | 10  |

Scenario: Verify behavior for an invalid endpoint
Given the base URL is "https://fakestoreapi.com/invalidEndpoint"
When I send a GET request to the endpoint
Then the request should fail
And the error message should contain "Cannot GET"

Scenario: Verify behavior for an invalid product ID
When I send a GET request to the endpoint with product ID 9999
Then the request should be successful
And the response should not contain details of a product
