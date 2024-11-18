using System;
using Newtonsoft.Json.Linq;
using RestSharp;
using TechTalk.SpecFlow;

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

        [Then(@"the response should contain the product with the following details:")]
        public void ThenTheResponseShouldContainTheProductWithTheFollowingDetails(Table table)
        {
            var responseJson = JObject.Parse(_context.Response.Content);

            foreach (var row in table.Rows)
            {
                var field = row["field"];

                // Check if the field exists in the JObject
                var property = responseJson.Property(field);

                // Assert that the field exists
                Assert.True(property != null, $"Field '{field}' is missing from the response.");

                // If the field is 'id', ensure the value is correct
                if (field == "id")
                {
                    var actualValue = property?.Value.ToString();
                    var expectedValue = row["value"];
                    Assert.Equal(expectedValue, actualValue); // Assert that id is correct
                }
            }
        }
    }
}
