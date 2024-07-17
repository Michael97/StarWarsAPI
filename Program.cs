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


//Get Characters from each film

// API request for each character -> cache results so don't do duplicate calls

var characterUrlCache = new HashSet<string>();

foreach (var film in films.Results)
{
    var serializedFilm = jsonSerializerService.Serialize(film);
    Console.WriteLine(serializedFilm);
    File.WriteAllText($"C:\\dev\\Tests\\StarWarsAPI\\Data\\Films\\{film.Title}.json", serializedFilm);

    foreach (var character in film.Characters)
    {
        characterUrlCache.Add(character);
    }
}

//Now we want API call for each character

foreach (var character in characterUrlCache)
{
    var characterResponse = await apiService.GetAsync<Character>(character);
    Console.WriteLine(characterResponse);
    var serializedCharacter = jsonSerializerService.Serialize(character);
    Console.WriteLine(serializedCharacter);
    File.WriteAllText($"C:\\dev\\Tests\\StarWarsAPI\\Data\\Characters\\{characterResponse.Name}.json", serializedFilms);
}