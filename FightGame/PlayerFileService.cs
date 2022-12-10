global using CsvHelper;
global using System.Globalization;

// REQUIREMENT #3 a Third Class Definition
// This is the PlayerFileService which saves player data into CSV files
public class PlayerFileService
{
    /// <summary>
    /// ReadPlayerScoresFromFile reads a players score from a file. It takes in a filename
    /// and will return a score which is of our generic type IScore
    /// </summary>
    public IScore<string, int> ReadPlayerScoresFromFile(string filename)
    {
        using (var reader = new StreamReader($"../Players/{filename}Score.csv"))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            var scores = csv.GetRecords<Score<string, int>>();
            return scores.First();
        }
    }
    /// <summary>
    /// WritePlayerScoresToFile writes the players scores to a file. It takes
    /// in a score which is of our own generic type
    /// </summary>
    public void WritePlayerScoresToFile(IScore<string, int> score)
    {
        using (var writer = new StreamWriter($"../Players/{score.NameOfPlayer}Score.csv"))
        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            var scores = new List<IScore<string, int>>() { score };
            csv.WriteRecords<IScore<string, int>>(scores);
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
            // REQUIREMENT #15 - built-in generic collection type
            // Creates an IEnumerable when it gets the records from the csv
            // Then it returns the first element
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