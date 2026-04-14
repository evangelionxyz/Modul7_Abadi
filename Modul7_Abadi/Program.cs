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
    public static void ReadJson(string filename)
    { 
        var fileString = File.ReadAllText(filename);
        var film = JsonSerializer.Deserialize<WatchList>(fileString);
        if (film != null)
        { 
            Console.WriteLine($" {film.Title} ({film.Year} - {film.Rating})");

        }

    }
}
public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("WatchList Name: Notebook");
        Console.WriteLine("Created By Kelompok Abadi");
        Console.WriteLine("Movies:");

        Film.ReadJson("jurnal7_1_103022430005.json");
    }
}