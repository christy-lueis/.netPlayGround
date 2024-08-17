namespace MyAppServices.models
{
   

    // Root myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(myJsonResponse);
    public class ReleaseDates
    {
        public string Japan { get; set; }
        public string NorthAmerica { get; set; }
        public string Europe { get; set; }
        public string Australia { get; set; }
    }

    public class GamesDS
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<string> genre { get; set; }
        public List<string> developers { get; set; }
        public List<string> publishers { get; set; }
        public ReleaseDates releaseDates { get; set; }
    }


}
