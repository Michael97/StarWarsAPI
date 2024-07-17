using StarWarsAPI.Model;
using StarWarsAPI.Services;

var jsonSerializerService = new JsonSerializerService();

var apiService = new ApiService(new HttpClient(), jsonSerializerService);

var films = await apiService.GetAsync<FilmsResponse>("https://swapi.dev/api/films");

Console.WriteLine($"Number of films: {films.Count}");
Console.WriteLine($"First Film: {films.Results[0].Title}");

var serializedFilms = jsonSerializerService.Serialize(films);

Console.WriteLine(serializedFilms);

File.WriteAllText(@"C:\dev\Tests\StarWarsAPI\Data\films.json", serializedFilms);