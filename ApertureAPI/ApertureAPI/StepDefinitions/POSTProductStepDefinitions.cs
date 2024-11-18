using Newtonsoft.Json.Linq;
using RestSharp;
using TechTalk.SpecFlow.Infrastructure;

namespace ApertureAPI.StepDefinitions
{
    [Binding]
    public class POSTProductStepDefinitions
    {
        private readonly ApiContext _context;
        private readonly ISpecFlowOutputHelper _specFlowOutputHelper;

        // Constructor: Initializes the API context for shared data and SpecFlow output helper for logging
        public POSTProductStepDefinitions(ApiContext context, ISpecFlowOutputHelper specFlowOutputHelper)
        {
            _context = context;
            _specFlowOutputHelper = specFlowOutputHelper;
        }

        // Step definition for sending a POST request with product data
        [When(@"I send a POST request with the following product data:")]
        public void WhenISendAPOSTRequestWithTheFollowingProductData(Table table)
        {
            var productData = new JObject(); // Creates a JSON object to hold the product data

            // Iterates through the table rows to populate the JSON object with product details
            foreach (var row in table.Rows)
            {
                productData["title"] = row["title"]; // Adds the product title to the JSON object
                productData["price"] = row["price"]; // Adds the product price
                productData["description"] = row["description"]; // Adds the product description
                productData["image"] = row["image"]; // Adds the product image URL
                productData["category"] = row["category"]; // Adds the product category
            }

            // Initializes the RestClient with the base URL
            var client = new RestClient(_context.baseUrl);

            // Prepares the POST request
            var request = new RestRequest("", Method.Post);

            // Attaches the product data as the request body
            request.AddJsonBody(productData);

            // Executes the POST request and stores the response in the API context
            _context.Response = client.Execute(request);
        }
    }
}
