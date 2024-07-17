namespace StarWarsAPI.Model
{
    public class Character
    {
        public string Name { get; set; } = string.Empty;
        public string Height { get; set; } = string.Empty;
        public string Mass { get; set; } = string.Empty;
        public string Hair_Color { get; set; } = string.Empty;
        public string Skin_Color { get; set; } = string.Empty;
        public string Eye_Color { get; set; } = string.Empty;
        public string Birth_Year { get; set; } = string.Empty;  
        public string Gender { get; set; } = string.Empty;
        public string Homeworld { get; set; } = string.Empty;
        public List<string> Films { get; set; } = new List<string>();
        public List<string> Species { get; set; } = new List<string>();
        public List<string> Vehicles { get; set; } = new List<string>();
        public List<string> Starships { get; set; } = new List<string>();
        public string Created { get; set; } = string.Empty;
        public string Edited { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
    }
}
