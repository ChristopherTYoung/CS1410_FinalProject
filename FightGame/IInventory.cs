// REQUIREMENT #14 - a Second Interface
// We use our second interface for Inventory. Inventory inherits from IInventory
// We use it for reading and writing to files, too.
public interface IInventory
{
    [Index(0)]
    public int UltimateAttacks { get; set; }
    [Index(1)]
    public int SpecialAttacks { get; set; }
    [Index(2)]
    public int Dodges { get; set; }
}