using Microsoft.Extensions.Configuration;
using StarWarsAPI.Model;
using StarWarsAPI.Services;
using NLog;
using NLog.Config;
using NLog.Extensions.Logging;
using Microsoft.Extensions.Logging;

try
{

    //Services
    var jsonSerializerService = new JsonSerializerService();
    var apiService = new ApiService(new HttpClient(), jsonSerializerService);
    var dataService = new DataService(jsonSerializerService);


    //Configuration File (Contains the data/save path)
    var appSettings = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
    var dataPath = appSettings.GetSection("Settings")["DataPath"];
    var logsPath = appSettings.GetSection("Settings")["LogsPath"];


    // Initialize NLog configuration
    var config = LogManager.Configuration;

    // Set the log directory to the current directory
    config.Variables["logDirectory"] = logsPath;

    Directory.CreateDirectory(logsPath);

    // Apply configuration
    LogManager.Configuration = config;

    var logger = LoggerFactory.Create(builder => builder.AddNLog()).CreateLogger<Program>();

   // var logger = LogManager.GetCurrentClassLogger();

    logger.LogInformation("Application Started");


    var films = await apiService.GetAsync<FilmsResponse>("https://swapi.dev/api/films");

    var serializedFilms = jsonSerializerService.Serialize(films);

    await dataService.SaveAsync($"{dataPath}\\films.json", films);

    //Get Characters from each film

    // API request for each character -> cache results so don't do duplicate calls

    var characterUrlCache = new HashSet<string>();

    Directory.CreateDirectory($"{dataPath}\\Films");
    Directory.CreateDirectory($"{dataPath}\\Characters");

    foreach (var film in films.Results)
    {
        // Serialise each Film
        await dataService.SaveAsync($"{dataPath}\\Films\\{film.Title}.json", film);

        foreach (var character in film.Characters)
        {
            if (characterUrlCache.Add(character))
            {
                // Use the URL to get the character data
                var characterResponse = await apiService.GetAsync<Character>(character);

                // Serialise and save character data
                await dataService.SaveAsync($"{dataPath}\\Characters\\{characterResponse.Name}.json", characterResponse);
            }
        }
    }
    Console.WriteLine("Successfully added all data to file");
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
    throw;
}