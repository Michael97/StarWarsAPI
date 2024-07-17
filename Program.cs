using StarWarsAPI.Model;
using StarWarsAPI.Services;
using System.Text.Json;

HttpClient client = new HttpClient();

var apiService = new ApiService(client);

var filmsResponse = await apiService.GetAsync<FilmsResponse>("https://swapi.dev/api/films");

var jsonService = new JsonSerializerService(new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

var films = jsonService.Deserialize<FilmsResponse>(filmsResponse);

Console.WriteLine($"Number of films: {films.Count}");
Console.WriteLine($"First Film: {films.Results[0].Title}");