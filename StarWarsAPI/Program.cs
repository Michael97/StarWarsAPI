using StarWarsAPI.Model;
using StarWarsAPI.Services;

//Services
var jsonSerializerService = new JsonSerializerService();
var apiService = new ApiService(new HttpClient(), jsonSerializerService);
var dataService = new DataService(jsonSerializerService);

var films = await apiService.GetAsync<FilmsResponse>("https://swapi.dev/api/films");

Console.WriteLine($"Number of films: {films.Count}");
Console.WriteLine($"First Film: {films.Results[0].Title}");

var serializedFilms = jsonSerializerService.Serialize(films);

Console.WriteLine(serializedFilms);

await dataService.SaveAsync($"C:\\dev\\Tests\\StarWarsAPI\\Data\\films.json", films);

//Get Characters from each film

// API request for each character -> cache results so don't do duplicate calls

var characterUrlCache = new HashSet<string>();

foreach (var film in films.Results)
{
    // Serialise each Film
    await dataService.SaveAsync($"C:\\dev\\Tests\\StarWarsAPI\\Data\\Films\\{film.Title}.json", film);

    foreach (var character in film.Characters)
    {
        if (characterUrlCache.Add(character))
        {
            // Use the URL to get the character data
            var characterResponse = await apiService.GetAsync<Character>(character);

            // Serialise and save character data
            await dataService.SaveAsync($"C:\\dev\\Tests\\StarWarsAPI\\Data\\Characters\\{characterResponse.Name}.json", characterResponse);
        }
    }
}
