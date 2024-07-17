namespace StarWarsAPI.Model
{
    public class FilmsResponse
    {
        public int Count { get; set; }
        public string Next { get; set; } = string.Empty;
        public string Previous { get; set; } = string.Empty;
        public List<Film> Results { get; set; } = new List<Film>();
    }
}