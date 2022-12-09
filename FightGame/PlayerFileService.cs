global using CsvHelper;
global using System.Globalization;
public class PlayerFileService
{
    public IEnumerable<IPlayer> ReadPlayerScoresFromFile()
    {
        return new List<IPlayer>();
    }
    public void WritePlayerScoresToFile()
    {

    }
    public IPlayer ReadPlayerSavedData(string filename)
    {
        using (var reader = new StreamReader($"../Players/{filename}.csv"))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            var record = csv.GetRecords<Player>();
            return record.First();
        }
    }
    public void WritePlayerSavedData(IPlayer player)
    {
        using (var writer = new StreamWriter($"../Players/{player.Name}.csv"))
        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            // csv.WriteHeader<IPlayer>();
            var players = new List<IPlayer>(){ player };
            csv.WriteRecords(players);
        }
    }
    public static IInventory ReadInventorySavedData(string filename)
    {
        using (var reader = new StreamReader($"../Players/{filename}Inventory.csv"))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            var record = csv.GetRecords<Inventory>();
            return record.First();
        }
    }
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