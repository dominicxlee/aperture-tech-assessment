using System.Net;
using Newtonsoft.Json.Linq;
using RestSharp;
using TechTalk.SpecFlow;
using Xunit;

[Binding]
public class GETCategoriesStepDefinitions
{

    private JArray _categories;
    private readonly ApiContext _context;

    public GETCategoriesStepDefinitions(ApiContext context)
    {
        _context = context;
    }

    [Then(@"the response should contain a list of categories")]
    public void ThenTheResponseShouldContainAListOfCategories()
    {
        TryParseResponseAsArray();
        Assert.True(_categories != null && _categories.Count > 0, "The response does not contain a valid list of categories.");
    }

    [Then(@"the response should contain the category ""(.*)""")]
    public void ThenTheResponseShouldContainTheCategory(string category)
    {
        TryParseResponseAsArray();
        Assert.Contains(category, _categories.ToObject<string[]>());
    }

    private void TryParseResponseAsArray()
    {
        try
        {
            _categories = JArray.Parse(_context.Response.Content);
        }
        catch
        {
            _categories = null;
        }
    }
}
