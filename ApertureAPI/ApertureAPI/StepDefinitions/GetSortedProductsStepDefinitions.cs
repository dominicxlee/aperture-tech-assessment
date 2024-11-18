using Newtonsoft.Json.Linq;
using TechTalk.SpecFlow;
using Xunit;

[Binding]
public class ProductsSteps
{
    private readonly ApiContext _context;

    public ProductsSteps(ApiContext context)
    {
        _context = context;
    }

    [Then(@"the response should contain products sorted in descending order by ID")]
    public void ThenTheResponseShouldContainProductsSortedInDescendingOrderByID()
    {
        Assert.NotNull(_context.Response);

        // Parse the response content to get the list of products
        var products = JArray.Parse(_context.Response.Content).ToObject<List<JObject>>();

        // Check if the products are sorted in descending order by ID
        for (int i = 0; i < products.Count - 1; i++)
        {
            int currentId = products[i]["id"].Value<int>();
            int nextId = products[i + 1]["id"].Value<int>();

            Assert.True(currentId >= nextId, $"Products are not sorted in descending order. Found {currentId} followed by {nextId}.");
        }
    }

    [Then(@"the response should contain products sorted in ascending order by ID")]
    public void ThenTheResponseShouldContainProductsSortedInAscendingOrderByID()
    {
        Assert.NotNull(_context.Response);

        // Parse the response content to get the list of products
        var products = JArray.Parse(_context.Response.Content).ToObject<List<JObject>>();

        // Check if the products are sorted in descending order by ID
        for (int i = 0; i < products.Count - 1; i++)
        {
            int currentId = products[i]["id"].Value<int>();
            int nextId = products[i + 1]["id"].Value<int>();

            Assert.True(currentId <= nextId, $"Products are not sorted in ascending order. Found {currentId} followed by {nextId}.");
        }
    }

}
