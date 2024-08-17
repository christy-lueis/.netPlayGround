using MyAppServices.models;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace MyAppServices.Services
{
    public class TestService
    {
        public async Task<IEnumerable<Recipe>> Get5Recipies(String query)
        {
            List<Recipe> recipes = new List<Recipe>();

            var url = $"https://api.sampleapis.com";
            //var parameters = $"?query={query}&apiKey={Consts.SPOONACULAR_API_KEY}&number=5";

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync(query);

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();

                if (jsonString != null)
                {
                    Console.WriteLine("Got it "+ query);
                }
            }

            return recipes;
        }

        public async Task<IEnumerable<Recipe>> Get6Recipies(String query)
        {
            List<Recipe> recipes = new List<Recipe>();

            var url = $"https://api.sampleapis.com";
            //var parameters = $"?query={query}&apiKey={Consts.SPOONACULAR_API_KEY}&number=5";

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync(query);

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();

                if (jsonString != null)
                {
                    Console.WriteLine("Got it " + query);
                }
            }

            return recipes;
        }

        public async Task<IEnumerable<Recipe>> Get7Recipies(String query)
        {
            List<Recipe> recipes = new List<Recipe>();

            var url = $"https://api.sampleapis.com";
            //var parameters = $"?query={query}&apiKey={Consts.SPOONACULAR_API_KEY}&number=5";

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync(query);

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();

                if (jsonString != null)
                {
                    Console.WriteLine("Got it " + query);
                }
            }

            return recipes;
        }

        public async Task Dogames(string query)
        {
            Console.WriteLine(query);

             Get5Recipies("switch/games");
             Get5Recipies("wines/reds");
            await Get5Recipies("coffee/hot");


        }
        public async Task Dowines(string query)
        {
            Console.WriteLine(query);


        }
        public async Task Docoffee(string query)
        {
            Console.WriteLine(query);


        }
    }
    [Serializable]
    public class RecipeList
    {
        [JsonProperty("results")]
        public IEnumerable<Recipe> Recipes { get; set; }
    }
    [Serializable]
    public class Recipe
    {
        [JsonProperty("title")]
        public string Title { get; set; }
    }
    public static class Consts
    {

        public static string SPOONACULAR_API_KEY = "MY_KEY";

    }
}

