using Newtonsoft.Json.Linq;
using RestSharp;

namespace ApertureAPI.StepDefinitions
{
    [Binding]
    public class PUTProductStepDefinitions
    {
        private readonly ApiContext _context;

        // Constructor: Initializes the API context to share data across step definitions
        public PUTProductStepDefinitions(ApiContext context)
        {
            _context = context;
        }

        // Step definition for sending a PUT request to update a product
        [When(@"I send a PUT request to update the product with the following details:")]
        public void WhenISendAPUTRequestToUpdateTheProductWithTheFollowingDetails(Table table)
        {
            var productData = new JObject(); // Creates a JSON object to hold the updated product data
            var id = ""; // Variable to store the product ID

            // Iterates through the table rows to populate the product data
            foreach (var row in table.Rows)
            {
                productData["title"] = row["title"]; // Adds the updated product title
                productData["price"] = row["price"]; // Adds the updated product price
                productData["description"] = row["description"]; // Adds the updated product description
                productData["image"] = row["image"]; // Adds the updated product image URL
                productData["category"] = row["category"]; // Adds the updated product category
                id = row["id"]; // Extracts the product ID to use in the PUT request URL
            }

            // Initializes the RestClient with the base URL
            var client = new RestClient(_context.baseUrl);

            // Prepares the PUT request, appending the product ID to the URL
            var request = new RestRequest(id, Method.Put);

            // Attaches the updated product data as the request body
            request.AddJsonBody(productData);

            // Executes the PUT request and stores the response in the API context
            _context.Response = client.Execute(request);
        }
    }
}
