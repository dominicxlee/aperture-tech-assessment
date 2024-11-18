# Aperture Tech Assessment

This repository contains a technical assessment project, demonstrating skills in API testing, UI testing, and overall project organization using SpecFlow, Selenium, xUnit, and other dependencies. It includes three key components:

## Project Structure

The repository is divided into the following folders:

### 1. **ApertureAPI**
A SpecFlow + xUnit project for testing API endpoints using **RestSharp**. The following API endpoints are tested:

- **GET** `https://fakestoreapi.com/products`
- **POST** `https://fakestoreapi.com/products` (ensures that post data is well-structured)
- **PUT** `https://fakestoreapi.com/products/{productId}`
- **DELETE** `https://fakestoreapi.com/products/{productId}`
- **GET** `https://fakestoreapi.com/products/categories`
- **GET** `https://fakestoreapi.com/products?sort=asc` (or other sort variations)

The API tests ensure that the endpoints behave as expected and validate the API responses.

### 2. **ApertureUI**
A SpecFlow + Selenium + xUnit project that performs UI tests on a website using Page Object Model (POM). The tests simulate the following user actions:

1. Open a browser and navigate to **Sauce Demo**.
2. Log in with test credentials.
3. Add a few products to the cart.
4. Go to the Cart and validate that all selected items are present.
5. Continue to checkout and validate the items and totals at each step.

These tests validate that the UI functions as intended and ensure the cart and checkout process works correctly.

### 3. **aperture-tech-assessment**
This is a solution folder that contains the main solution file for the project. When opened in **Visual Studio**, it loads all three projects (ApertureAPI, ApertureUI, and the solution itself) for easy access and running of tests across both API and UI projects.

## Dependencies

The following dependencies are required to run the tests:

1. **SpecFlow Extension** for Visual Studio 2022 – for behavior-driven development (BDD) using Gherkin syntax.
2. **Selenium WebDriver** – for automating web browsers to perform UI tests.
3. **xUnit** – a testing framework for running and organizing tests.
4. **Fluent Assertions** – for improved readability and ease of use in assertions.
5. **RestSharp** – for making HTTP requests in API testing.

Ensure that all dependencies are installed before running the tests. You can find installation instructions in their respective documentation.

## Getting Started

1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/aperture-tech-assessment.git
   ```
2. Open the `aperture-tech-assessment.sln` solution file in **Visual Studio**.
3. Restore the NuGet packages for the solution:
   - Right-click on the solution in Solution Explorer and select **Restore NuGet Packages**.
4. Run the tests:
   - **ApertureAPI Tests**: Right-click the `ApertureAPI` project and select **Run Tests**.
   - **ApertureUI Tests**: Right-click the `ApertureUI` project and select **Run Tests**.

## Running the Tests

The tests are organized as follows:

- **API Tests** (ApertureAPI):
  - The API tests are executed through xUnit and can be run using Visual Studio's built-in test runner.

- **UI Tests** (ApertureUI):
  - The UI tests utilize Selenium WebDriver to automate browser interactions. Ensure that you have the necessary browser drivers installed (e.g., ChromeDriver) for your system.
