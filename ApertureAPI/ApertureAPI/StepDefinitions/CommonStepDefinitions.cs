using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using RestSharp;


    [Binding]
    public class CommonStepDefinitions
    {
        private readonly ApiContext _context;

        public CommonStepDefinitions(ApiContext context)
        {
            _context = context;
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
            Console.WriteLine($"Status Code: {_context.Response.StatusCode}");
            Console.WriteLine($"Response Body: {_context.Response.Content}");
        }

        [Then(@"the error message should contain ""(.*)""")]
        public void ThenTheErrorMessageShouldContain(string expectedMessage)
        {
            var errorMessage = _context.Response.Content;
            Assert.Contains(expectedMessage, errorMessage, StringComparison.OrdinalIgnoreCase);
        }

    }

