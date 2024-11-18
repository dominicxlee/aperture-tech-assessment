using System.Net;
using Newtonsoft.Json.Linq;
using RestSharp;
using TechTalk.SpecFlow;
using Xunit;

[Binding]
public class GETProductsStepDefinitions
{
    private JArray _products;

    private readonly ApiContext _context;

    public GETProductsStepDefinitions(ApiContext context)
    {
        _context = context;
    }

    [When(@"I send a GET request to the endpoint with product ID (.*)")]
    public void WhenISendAGETRequestToTheEndpointWithProductID(int productId)
    {
        var client = new RestClient($"{_context.baseUrl}/{productId}");
        var request = new RestRequest("", Method.Get);
        _context.Response = client.Execute(request);
        LogResponseDetails();
    }

    [Then(@"the response should contain a list of products")]
    public void ThenTheResponseShouldContainAListOfProducts()
    {
        TryParseResponseAsArray();
        Assert.True(_products != null && _products.Count > 0, "The response does not contain a valid list of products.");
    }

    [Then(@"the response should contain a product with id (.*)")]
    public void ThenTheResponseShouldContainAProductWithId(int id)
    {
        TryParseResponseAsArray();
        var product = _products?.FirstOrDefault(p => (int)p["id"] == id);
        Assert.NotNull(product);
    }

    [Then(@"the product should have a (.*)")]
    public void ThenTheProductShouldHaveA(string field)
    {
        TryParseResponseAsArray();
        Assert.All(_products, product =>
        {
            Assert.True(product[field] != null && !string.IsNullOrEmpty(product[field].ToString()),
                $"The product is missing the field: {field}");
        });
    }

    [Then(@"the response should not contain details of a product")]
    public void ThenTheResponseShouldNotContainDetailsOfAProduct()
    {
        Assert.Empty(_context.Response.Content);
    }

    private void LogResponseDetails()
    {
        Console.WriteLine($"Status Code: {_context.Response.StatusCode}");
        Console.WriteLine($"Response Body: {_context.Response.Content}");
    }

    private void TryParseResponseAsArray()
    {
        try
        {
            _products = JArray.Parse(_context.Response.Content);
        }
        catch
        {
            _products = null;
        }
    }

}
