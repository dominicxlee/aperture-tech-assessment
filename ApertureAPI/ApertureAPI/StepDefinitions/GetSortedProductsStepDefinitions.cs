using Newtonsoft.Json.Linq;

namespace ApertureAPI.StepDefinitions
{
    [Binding]
    public class ProductsSteps
    {
        private readonly ApiContext _context; // Stores the shared context containing the response from the API

        // Constructor: Initializes the ApiContext to access the response data
        public ProductsSteps(ApiContext context)
        {
            _context = context;
        }

        // Step definition to verify that the response contains products sorted in descending order by ID
        [Then(@"the response should contain products sorted in descending order by ID")]
        public void ThenTheResponseShouldContainProductsSortedInDescendingOrderByID()
        {
            Assert.NotNull(_context.Response); // Asserts that the response is not null

            // Parse the response content into a list of product objects
            var products = JArray.Parse(_context.Response.Content).ToObject<List<JObject>>();

            // Loop through the products to ensure they are sorted in descending order by ID
            for (int i = 0; i < products.Count - 1; i++)
            {
                // Retrieve the current and next product IDs
                int currentId = products[i]["id"].Value<int>();
                int nextId = products[i + 1]["id"].Value<int>();

                // Assert that the current ID is greater than or equal to the next ID
                Assert.True(currentId >= nextId, $"Products are not sorted in descending order. Found {currentId} followed by {nextId}.");
            }
        }

        // Step definition to verify that the response contains products sorted in ascending order by ID
        [Then(@"the response should contain products sorted in ascending order by ID")]
        public void ThenTheResponseShouldContainProductsSortedInAscendingOrderByID()
        {
            Assert.NotNull(_context.Response); // Asserts that the response is not null

            // Parse the response content into a list of product objects
            var products = JArray.Parse(_context.Response.Content).ToObject<List<JObject>>();

            // Loop through the products to ensure they are sorted in ascending order by ID
            for (int i = 0; i < products.Count - 1; i++)
            {
                // Retrieve the current and next product IDs
                int currentId = products[i]["id"].Value<int>();
                int nextId = products[i + 1]["id"].Value<int>();

                // Assert that the current ID is less than or equal to the next ID
                Assert.True(currentId <= nextId, $"Products are not sorted in ascending order. Found {currentId} followed by {nextId}.");
            }
        }

    }
}
