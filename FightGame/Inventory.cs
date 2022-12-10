//REQUIREMENT #4 a Struct Definition
// Contains the amount of Ultimate attacks, SpecialAttacks, and Dodges
// It felt appropriate to hold small values like this in a struct
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
    //REQUIREMENT #7 polymorphism
    //This struct overrides ToString to display the inventory a certain way
    public override string ToString()
    {
        return $"Ultimate Attacks: {UltimateAttacks} | Special Attacks: {SpecialAttacks} | Dodges: {Dodges}";
    }
}