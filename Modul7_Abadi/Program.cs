using System.Text.Json;
using System.Text.Json.Serialization;

public class WatchList
{
    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("director")]
    public string Director { get; set; }

    [JsonPropertyName("year")]
    public int Year { get; set; }

    [JsonPropertyName("genre")]
    public string Genre { get; set; }

    [JsonPropertyName("rating")]
    public double Rating { get; set; }

    [JsonPropertyName("durationMinutes")]
    public int DurationMinutes { get; set; }

    [JsonPropertyName("isWatched")]
    public bool IsWatched { get; set; }
}

public class Film
{
    public static void ReadJSON(string filename)
    {
        var fileString = File.ReadAllText(filename);
        var film = JsonSerializer.Deserialize<WatchList>(fileString);
        if (film != null)
        {
            Console.WriteLine($" {film.Title} ({film.Year} - {film.Rating})");
        }
    }
}

public class ListName
{
    [JsonPropertyName("watchlistName")]
    public string WatchListName { get; set; }

    [JsonPropertyName("createdBy")]
    public string CreatedBy { get; set; }

    [JsonPropertyName("movies")]
    public List<WatchList> Movies { get; set; } = new List<WatchList>();
}

public class WatchListFilm
{
    public static void ReadJSON(string filename)
    {
        var fileString = File.ReadAllText(filename);
        var listName = JsonSerializer.Deserialize<ListName>(fileString);
        if (listName != null)
        {
            Console.WriteLine($"Watchlist: {listName.WatchListName}");
            Console.WriteLine($"Created by: {listName.CreatedBy}");

            foreach (var item in listName.Movies)
            {
                Console.WriteLine($" {item.Title} ({item.Year} - {item.Rating})");
            }

        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Watchlist Name: Weekend Marathon");
        Console.WriteLine("Created By: Kelompok Abadi");
        Console.WriteLine("Movies:");

        Film.ReadJSON("jurnal7_1_103022300164.json");
        Film.ReadJSON("jurnal7_1_103022430005.json");
        Film.ReadJSON("jurnal7_1_103022400072.json");
        Film.ReadJSON("Jurnal7_1_103022400060.json");
        Film.ReadJSON("jurnal7_1_103022400026.json");

        WatchListFilm.ReadJSON("jurnal7_2_103022300164.json");
    }
}