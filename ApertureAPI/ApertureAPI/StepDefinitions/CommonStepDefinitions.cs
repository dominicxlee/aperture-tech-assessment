using System.Net;
using Newtonsoft.Json.Linq;
using RestSharp;
using TechTalk.SpecFlow.Infrastructure;


[Binding]
    public class CommonStepDefinitions
    {
        private readonly ApiContext _context;
    private readonly ISpecFlowOutputHelper _specFlowOutputHelper;

    public CommonStepDefinitions(ApiContext context, ISpecFlowOutputHelper specFlowOutputHelper)
        {
            _context = context;
            _specFlowOutputHelper = specFlowOutputHelper;
    }

        [Given(@"the base URL is ""(.*)""")]
        public void GivenTheBaseUrlIs(string baseUrl)
        {
            _context.baseUrl = baseUrl;
        }

        [When(@"I send a GET request to the endpoint")]
        public void WhenISendAGETRequestToTheEndpoint()
        {
            var client = new RestClient(_context.baseUrl);
            var request = new RestRequest("", Method.Get);
            _context.Response = client.Execute(request);
            LogResponseDetails();
        }

        [Then(@"the response code should be (.*)")]
        public void ThenTheResponseCodeShouldBe(int statusCode)
        {
            Assert.Equal((HttpStatusCode)statusCode, _context.Response.StatusCode);
        }

        private void LogResponseDetails()
        {
        _specFlowOutputHelper.WriteLine($"Status Code: {_context.Response.StatusCode}");
        _specFlowOutputHelper.WriteLine($"Response Body: {_context.Response.Content}");
        }

        [Then(@"the error message should contain ""(.*)""")]
        public void ThenTheErrorMessageShouldContain(string expectedMessage)
        {
            var errorMessage = _context.Response.Content;
            Assert.Contains(expectedMessage, errorMessage, StringComparison.OrdinalIgnoreCase);
        }

    [Then(@"the response should contain the product with the following details:")]
    public void ThenTheResponseShouldContainTheProductWithTheFollowingDetails(Table table)
    {
        var responseJson = JObject.Parse(_context.Response.Content);

        foreach (var row in table.Rows)
        {
            var field = row["field"];

            // Check if the field exists
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

