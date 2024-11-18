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

        public POSTProductStepDefinitions(ApiContext context, ISpecFlowOutputHelper specFlowOutputHelper)
        {
            _context = context;
            _specFlowOutputHelper = specFlowOutputHelper;
        }

        [When(@"I send a POST request with the following product data:")]
        public void WhenISendAPOSTRequestWithTheFollowingProductData(Table table)
        {
            var productData = new JObject();
            foreach (var row in table.Rows)
            {

                productData["title"] = row["title"];
                productData["price"] = row["price"];
                productData["description"] = row["description"];
                productData["image"] = row["image"];
                productData["category"] = row["category"];
                    
            }

            var client = new RestClient(_context.baseUrl);
            var request = new RestRequest("", Method.Post);
            request.AddJsonBody(productData);
            _context.Response = client.Execute(request);
        }

    }
}
