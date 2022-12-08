public struct Inventory : IInventory
{
    public static int UltimateAttacks { get; set; } = 1;
    public static int SpecialAttacks { get; set; } = 3;
    public static int Dodges { get; set; } = 0;
    public static int HealingPotions { get; set; } = 3;
    public Inventory()
    {

    }
}