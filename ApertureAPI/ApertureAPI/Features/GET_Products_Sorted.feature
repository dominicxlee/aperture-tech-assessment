Feature: Get Sorted Products

Scenario: Verify that products are sorted in descending order by ID
Given the base URL is "https://fakestoreapi.com/products?sort=desc"
When I send a GET request to the endpoint 
Then the request should be successful
And the response should contain products sorted in descending order by ID

Scenario: Verify that products are sorted in ascending order by ID
Given the base URL is "https://fakestoreapi.com/products?sort=asc"
When I send a GET request to the endpoint 
Then the request should be successful
And the response should contain products sorted in ascending order by ID