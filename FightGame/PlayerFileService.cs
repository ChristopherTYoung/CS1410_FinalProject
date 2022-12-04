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
            csv.Read();
            var record = csv.GetRecord<IPlayer>();
            return record!;
        }
    }
    public void WritePlayerSavedData(IPlayer player)
    {
        using (var writer = new StreamWriter($"../Players/{player.Name}.csv"))
        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            csv.WriteRecord(player);
        }
    }
    public static IInventory ReadInventorySavedData(string filename)
    {
        using (var reader = new StreamReader($"../Players/{filename}Inventory.csv"))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            var record = csv.GetRecord<IInventory>();
            return record!;
        }
    }
    public static void WriteInventorySavedData(string filename, Inventory inventory)
    {
        using (var writer = new StreamWriter($"../Players/{filename}Inventory.csv"))
        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            csv.WriteRecord(inventory);
        }
    }
}