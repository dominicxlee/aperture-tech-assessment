using Newtonsoft.Json.Linq;
using RestSharp;

namespace ApertureAPI.StepDefinitions
{
    [Binding]
    public class GETProductsStepDefinitions
    {
        private JArray _products; // Holds the parsed response as a JSON array of products

        private readonly ApiContext _context; // Shared context to store the API response and other shared data

        // Constructor: Initializes the API context for accessing the response
        public GETProductsStepDefinitions(ApiContext context)
        {
            _context = context;
        }

        // Step definition for sending a GET request to retrieve product details by ID
        [When(@"I send a GET request to the endpoint with product ID (.*)")]
        public void WhenISendAGETRequestToTheEndpointWithProductID(int productId)
        {
            // Builds the GET request URL using the base URL and the product ID
            var client = new RestClient($"{_context.baseUrl}/{productId}");
            var request = new RestRequest("", Method.Get);
            _context.Response = client.Execute(request); // Executes the request and stores the response in context
            LogResponseDetails(); // Logs the details of the response (for debugging purposes)
        }

        // Step definition for verifying that the response contains a list of products
        [Then(@"the response should contain a list of products")]
        public void ThenTheResponseShouldContainAListOfProducts()
        {
            TryParseResponseAsArray(); // Attempts to parse the response content as a JSON array
            Assert.True(
                _products != null && _products.Count > 0,
                "The response does not contain a valid list of products."
            ); // Ensures that the response is not null and contains at least one product
        }

        // Step definition for verifying that the response contains a product with a specific ID
        [Then(@"the response should contain a product with id (.*)")]
        public void ThenTheResponseShouldContainAProductWithId(int id)
        {
            TryParseResponseAsArray(); // Attempts to parse the response content as a JSON array
            // Finds the product with the specified ID in the response array
            var product = _products?.FirstOrDefault(p => (int)p["id"] == id);
            Assert.NotNull(product); // Asserts that the product with the given ID is found
        }

        // Step definition for verifying that every product in the response has a specific field
        [Then(@"the product should have a (.*)")]
        public void ThenTheProductShouldHaveA(string field)
        {
            TryParseResponseAsArray(); // Attempts to parse the response content as a JSON array
            // Iterates through all products in the list and checks if the specified field exists and is not empty
            Assert.All(_products, product =>
            {
                Assert.True(
                    product[field] != null && !string.IsNullOrEmpty(product[field].ToString()),
                    $"The product is missing the field: {field}"
                );
            });
        }

        // Step definition for verifying that the response contains no product details (empty response)
        [Then(@"the response should not contain details of a product")]
        public void ThenTheResponseShouldNotContainDetailsOfAProduct()
        {
            Assert.Empty(_context.Response.Content); // Asserts that the response body is empty
        }

        // Helper method to log response details for debugging
        private void LogResponseDetails()
        {
            Console.WriteLine($"Status Code: {_context.Response.StatusCode}"); // Logs the status code
            Console.WriteLine($"Response Body: {_context.Response.Content}"); // Logs the response body content
        }

        // Helper method to attempt parsing the response content as a JSON array
        private void TryParseResponseAsArray()
        {
            try
            {
                _products = JArray.Parse(_context.Response.Content); // Parses the response as a JSON array
            }
            catch
            {
                _products = null; // If parsing fails, set _products to null
            }
        }

    }
}
