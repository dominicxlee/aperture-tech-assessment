using Newtonsoft.Json.Linq;

namespace ApertureAPI.StepDefinitions
{
    [Binding]
    public class GETCategoriesStepDefinitions
    {
        private JArray _categories; // Holds the parsed response as a JSON array of categories
        private readonly ApiContext _context; // Shared context to store the API response and other shared data

        // Constructor: Initializes the API context for accessing the response
        public GETCategoriesStepDefinitions(ApiContext context)
        {
            _context = context;
        }

        // Step definition to verify the response contains a valid list of categories
        [Then(@"the response should contain a list of categories")]
        public void ThenTheResponseShouldContainAListOfCategories()
        {
            TryParseResponseAsArray(); // Attempts to parse the API response as a JSON array
            Assert.True(
                _categories != null && _categories.Count > 0,
                "The response does not contain a valid list of categories."
            ); // Ensures the response is not null and contains at least one category
        }

        // Step definition to verify the response includes a specific category
        [Then(@"the response should contain the category ""(.*)""")]
        public void ThenTheResponseShouldContainTheCategory(string category)
        {
            TryParseResponseAsArray(); // Attempts to parse the API response as a JSON array
            Assert.Contains(
                category,
                _categories.ToObject<string[]>()
            ); // Checks if the specific category exists in the response
        }

        // Helper method to parse the API response content as a JSON array
        private void TryParseResponseAsArray()
        {
            try
            {
                _categories = JArray.Parse(_context.Response.Content); // Parses the response content into a JArray
            }
            catch
            {
                _categories = null; // Sets _categories to null if parsing fails
            }
        }
    }
}
