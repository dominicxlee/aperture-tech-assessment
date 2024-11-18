using Newtonsoft.Json.Linq;
using RestSharp;

namespace ApertureAPI.StepDefinitions
{
    [Binding]
    public class DELETEProductStepDefinitions
    {
        private readonly ApiContext _context;

        // Constructor: Initializes the API context for shared data between step definitions
        public DELETEProductStepDefinitions(ApiContext context)
        {
            _context = context;
        }

        // Step definition for sending a DELETE request to remove a product
        [When(@"I send a DELETE request to remove the product with the following details:")]
        public void WhenISendADELETERequestToRemoveTheProductWithTheFollowingDetails(Table table)
        {
            var productData = new JObject(); // Creates a JSON object to hold product data
            var id = ""; // Variable to store the product ID

            // Iterates through the table rows to populate product data
            foreach (var row in table.Rows)
            {
                productData["title"] = row["title"]; // Adds the product title to the JSON object
                productData["price"] = row["price"]; // Adds the product price
                productData["description"] = row["description"]; // Adds the product description
                productData["image"] = row["image"]; // Adds the product image URL
                productData["category"] = row["category"]; // Adds the product category
                id = row["id"]; // Retrieves the product ID for the DELETE request endpoint
            }

            // Sets up the RestClient with the base URL
            var client = new RestClient(_context.baseUrl);

            // Configures the DELETE request, appending the product ID to the URL
            var request = new RestRequest(id, Method.Delete);

            // Adds the product data as the request body (not always required for DELETE requests, but included here)
            request.AddJsonBody(productData);

            // Executes the DELETE request and stores the response in the API context
            _context.Response = client.Execute(request);
        }
    }
}
