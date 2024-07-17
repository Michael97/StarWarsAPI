using StarWarsAPI.Model;
using StarWarsAPI.Services;
using System.Text.Json;


var apiService = new ApiService(new HttpClient(), new JsonSerializerService());

var films = await apiService.GetAsync<FilmsResponse>("https://swapi.dev/api/films");

Console.WriteLine($"Number of films: {films.Count}");
Console.WriteLine($"First Film: {films.Results[0].Title}");