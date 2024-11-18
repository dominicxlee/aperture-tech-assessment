using System.Net;
using Newtonsoft.Json.Linq;
using RestSharp;
using TechTalk.SpecFlow.Infrastructure;

namespace ApertureAPI.StepDefinitions
{

    [Binding]
    public class CommonStepDefinitions
    {
        private readonly ApiContext _context;
        private readonly ISpecFlowOutputHelper _specFlowOutputHelper;

        // Constructor: Initializes the API context and SpecFlow output helper for logging
        public CommonStepDefinitions(ApiContext context, ISpecFlowOutputHelper specFlowOutputHelper)
        {
            _context = context;
            _specFlowOutputHelper = specFlowOutputHelper;
        }

        // Step definition for setting the base URL
        [Given(@"the base URL is ""(.*)""")]
        public void GivenTheBaseUrlIs(string baseUrl)
        {
            _context.baseUrl = baseUrl; // Stores the base URL in the shared API context
        }

        // Step definition for sending a GET request to the endpoint
        [When(@"I send a GET request to the endpoint")]
        public void WhenISendAGETRequestToTheEndpoint()
        {
            var client = new RestClient(_context.baseUrl); // Creates a new REST client using the base URL
            var request = new RestRequest("", Method.Get); // Prepares a GET request
            _context.Response = client.Execute(request); // Executes the request and stores the response in the API context
            LogResponseDetails(); // Logs the response details for debugging or reporting purposes
        }

        // Step definition for verifying that the request was successful
        [Then(@"the request should be successful")]
        public void ThenTheRequestShouldBeSuccessful()
        {
            _context.Response.IsSuccessful.Should().BeTrue(); // Asserts that the response indicates success
        }

        // Helper method to log response details
        private void LogResponseDetails()
        {
            _specFlowOutputHelper.WriteLine($"Status Code: {_context.Response.StatusCode}"); // Logs the response status code
            _specFlowOutputHelper.WriteLine($"Response Body: {_context.Response.Content}"); // Logs the response body
        }

        // Step definition for verifying that the error message contains a specific text
        [Then(@"the error message should contain ""(.*)""")]
        public void ThenTheErrorMessageShouldContain(string expectedMessage)
        {
            var errorMessage = _context.Response.Content; // Extracts the error message from the response body
            Assert.Contains(expectedMessage, errorMessage, StringComparison.OrdinalIgnoreCase); // Asserts that the error message contains the expected text
        }

        // Step definition for verifying that the response contains specific product details
        [Then(@"the response should contain the product with the following details:")]
        public void ThenTheResponseShouldContainTheProductWithTheFollowingDetails(Table table)
        {
            var responseJson = JObject.Parse(_context.Response.Content); // Parses the response body as JSON

            foreach (var row in table.Rows) // Iterates over each row in the provided data table
            {
                var field = row["field"]; // Gets the field name from the current row

                // Checks if the field exists in the response JSON
                var property = responseJson.Property(field);

                // Asserts that the field is present in the response
                Assert.True(property != null, $"Field '{field}' is missing from the response.");

                // If the field is 'id', validates its value
                if (field == "id")
                {
                    var actualValue = property?.Value.ToString(); // Retrieves the actual value from the response
                    var expectedValue = row["value"]; // Retrieves the expected value from the data table
                    Assert.Equal(expectedValue, actualValue); // Asserts that the actual and expected values match
                }
            }
        }
    }
}