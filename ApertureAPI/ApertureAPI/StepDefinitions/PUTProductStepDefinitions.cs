using Newtonsoft.Json.Linq;
using RestSharp;

namespace ApertureAPI.StepDefinitions
{
    [Binding]
    public class PUTProductStepDefinitions
    {
        private readonly ApiContext _context;

        public PUTProductStepDefinitions(ApiContext context)
        {
            _context = context;
        }

        [Given(@"I send a PUT request to update the product with the following details:")]
        public void GivenISendAPUTRequestToUpdateTheProductWithTheFollowingDetails(Table table)
        {
            var productData = new JObject();
            var id = "";
            foreach (var row in table.Rows)
            {
                productData["title"] = row["title"];
                productData["price"] = row["price"];
                productData["description"] = row["description"];
                productData["image"] = row["image"];
                productData["category"] = row["category"];
                id = row["id"];
            }

            var client = new RestClient(_context.baseUrl);
            var request = new RestRequest(id, Method.Put);
            request.AddJsonBody(productData);

            _context.Response = client.Execute(request);
        }
    }
}
