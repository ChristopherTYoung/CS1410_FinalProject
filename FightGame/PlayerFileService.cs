global using CsvHelper;
global using System.Globalization;

// REQUIREMENT #3 a Third Class Definition
// This is the PlayerFileService which saves player data into CSV files
public class PlayerFileService
{
    public IEnumerable<Score<string, int>> ReadPlayerScoresFromFile()
    {
        using (var reader = new StreamReader("../Players/Leaderboard.csv"))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            csv.Read();
            var scores = new List<Score<string, int>>();
            var scoreList = csv.GetRecords<Score<string, int>>();
            foreach(var score in scoreList)
            {
                scores.Append(score);
            }
            return scores;
        }
    }
    public void WritePlayerScoresToFile(Score<string, int> score, IEnumerable<Score<string, int>> scores)
    {
        using (var writer = new StreamWriter("../Players/Leaderboard.csv"))
        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            scores.Append(score);
            foreach(var s in scores)
            {
            csv.WriteRecord<Score<string, int>>(s);
            }
        }
    }
    /// <summary>
    /// ReadPlayerSavedData reads any previously saved player data from a csv
    /// </summary>
    public IPlayer ReadPlayerSavedData(string filename)
    {
        using (var reader = new StreamReader($"../Players/{filename}.csv"))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            var record = csv.GetRecords<Player>();
            return record.First();
        }
    }
    /// <summary>
    /// WritePlayerSavedData takes in an IPlayer and will save the player's data into a csv
    /// </summary>
    public void WritePlayerSavedData(IPlayer player)
    {
        using (var writer = new StreamWriter($"../Players/{player.Name}.csv"))
        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            var players = new List<IPlayer>() { player };
            csv.WriteRecords(players);
        }
    }
    /// <summary>
    /// ReadInventorySavedData reads any previously saved inventory data from a csv.
    /// If the player had no ultimate attacks the last time they quit, they still will have no ultimate attacks
    /// </summary>
    public static IInventory ReadInventorySavedData(string filename)
    {
        using (var reader = new StreamReader($"../Players/{filename}Inventory.csv"))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            var record = csv.GetRecords<Inventory>();
            return record.First();
        }
    }
    /// <summary>
    /// WriteInventorySavedData saves a players inventory data to a csv so they can start from where they left off later.
    /// It takes in a string filename and an IInventory
    /// </summary>
    public static void WriteInventorySavedData(string filename, IInventory inventory)
    {
        using (var writer = new StreamWriter($"../Players/{filename}Inventory.csv"))
        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            var inventories = new List<IInventory>() { inventory };
            csv.WriteRecords(inventories);
        }
    }
}