Feature: DELETE request to remove a product

  As a user of the API
  I want to send a DELETE request to remove a product
  So that I can verify that the product details are returned with the same ID, but nothing is actually updated in the database.

  Background:
    Given the base URL is "https://fakestoreapi.com/products/"

  Scenario Outline: Verifying the removed product details returned by DELETE request
    Given I send a DELETE request to remove the product with the following details:
      | title   | price   | description   | image   | category   | id   |
      | <title> | <price> | <description> | <image> | <category> | <id> |
    Then the response code should be 200
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

