using StarWarsAPI.Model;
using StarWarsAPI.Services;

HttpClient client = new HttpClient();

var apiService = new ApiService(client);

var films = await apiService.GetAsync<FilmsResponse>("https://swapi.dev/api/films");

Console.WriteLine($"Number of films: {films.Count}");
Console.WriteLine($"First Film: {films.Results[0].Title}");