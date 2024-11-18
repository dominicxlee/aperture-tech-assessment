Feature: GET Categories

Background:
Given the base URL is "https://fakestoreapi.com/products/categories"

Scenario: Verify that the API returns a valid response
When I send a GET request to the endpoint
Then the request should be successful
And the response should contain a list of categories

Scenario: Verify the list of categories contains expected values
When I send a GET request to the endpoint
Then the response should contain the category "electronics"
And the response should contain the category "jewelery"
And the response should contain the category "men's clothing"
And the response should contain the category "women's clothing"
