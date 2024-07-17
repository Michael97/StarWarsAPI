namespace StarWarsAPI.Model
{
    public class Film
    {
        public string Title { get; set; } = string.Empty;
        public int Episode_Id { get; set; }
        public string Opening_Crawl { get; set; } = string.Empty;
        public string Director { get; set; } = string.Empty;
        public string Producer { get; set; } = string.Empty;
        public string Release_Date { get; set; } = string.Empty;
        public List<string> Characters { get; set; } = new List<string>();
        public List<string> Planets { get; set; } = new List<string>();
        public List<string> Starships { get; set; } = new List<string>();
        public List<string> Vehicles { get; set; } = new List<string>();
        public List<string> Species { get; set; } = new List<string>();
        public string Created { get; set; } = string.Empty;
        public string Edited { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
    }
}
