using System.Net;
using Newtonsoft.Json.Linq;
using RestSharp;
using TechTalk.SpecFlow;
using Xunit;

[Binding]
public class GETProductsStepDefinitions
{
    private string _baseUrl;
    private RestResponse _response;
    private JArray _products;
    private JObject _product;

    [Given(@"the base URL is ""(.*)""")]
    public void GivenTheBaseUrlIs(string baseUrl)
    {
        _baseUrl = baseUrl;
    }

    [When(@"I send a GET request to the endpoint")]
    public void WhenISendAGETRequestToTheEndpoint()
    {
        var client = new RestClient(_baseUrl);
        var request = new RestRequest("", Method.Get);
        _response = client.Execute(request);
        LogResponseDetails();
        TryParseResponseAsArray();
    }

    [When(@"I send a GET request to the endpoint with product ID (.*)")]
    public void WhenISendAGETRequestToTheEndpointWithProductID(int productId)
    {
        var client = new RestClient($"{_baseUrl}/{productId}");
        var request = new RestRequest("", Method.Get);
        _response = client.Execute(request);
        LogResponseDetails();
        TryParseResponseAsObject();
    }

    [Then(@"the response code should be (.*)")]
    public void ThenTheResponseCodeShouldBe(int statusCode)
    {
        Assert.Equal((HttpStatusCode)statusCode, _response.StatusCode);
    }

    [Then(@"the response should contain a list of products")]
    public void ThenTheResponseShouldContainAListOfProducts()
    {
        Assert.True(_products != null && _products.Count > 0, "The response does not contain a valid list of products.");
    }

    [Then(@"the response should contain a product with id (.*)")]
    public void ThenTheResponseShouldContainAProductWithId(int id)
    {
        var product = _products?.FirstOrDefault(p => (int)p["id"] == id);
        Assert.NotNull(product);
    }

    [Then(@"the product should have a (.*)")]
    public void ThenTheProductShouldHaveA(string field)
    {
        Assert.All(_products, product =>
        {
            Assert.True(product[field] != null && !string.IsNullOrEmpty(product[field].ToString()),
                $"The product is missing the field: {field}");
        });
    }

    [Then(@"the response should not contain details of a product")]
    public void ThenTheResponseShouldNotContainDetailsOfAProduct()
    {
        Assert.Empty(_response.Content);
    }


    [Then(@"the error message should contain ""(.*)""")]
    public void ThenTheErrorMessageShouldContain(string expectedMessage)
    {
        var errorMessage = _response.Content;
        Assert.Contains(expectedMessage, errorMessage, StringComparison.OrdinalIgnoreCase);
    }

    private void LogResponseDetails()
    {
        Console.WriteLine($"Status Code: {_response.StatusCode}");
        Console.WriteLine($"Response Body: {_response.Content}");
    }

    private void TryParseResponseAsArray()
    {
        try
        {
            _products = JArray.Parse(_response.Content);
        }
        catch
        {
            _products = null;
        }
    }

    private void TryParseResponseAsObject()
    {
        try
        {
            _product = JObject.Parse(_response.Content);
        }
        catch
        {
            _product = null;
        }
    }
}
