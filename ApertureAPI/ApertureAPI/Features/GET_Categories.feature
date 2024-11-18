Feature: GET Categories
  Verify the functionality of the `https://fakestoreapi.com/products/categories` endpoint, ensuring it retrieves product categories correctly.

  Background:
    Given the base URL is "https://fakestoreapi.com/products/categories"

  Scenario: Verify that the API returns a valid response
    When I send a GET request to the endpoint
    Then the response code should be 200
    And the response should contain a list of categories

  Scenario: Verify the list of categories contains expected values
    When I send a GET request to the endpoint
    Then the response should contain the category "electronics"
    And the response should contain the category "jewelery"
    And the response should contain the category "men's clothing"
    And the response should contain the category "women's clothing"
