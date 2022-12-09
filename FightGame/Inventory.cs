public struct Inventory : IInventory
{
    [Index(0)]
    public int UltimateAttacks { get; set; } = 1;
    [Index(1)]
    public int SpecialAttacks { get; set; } = 3;
    [Index(2)]
    public int Dodges { get; set; } = 1;
    public Inventory()
    {

    }
}