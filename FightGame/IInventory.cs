public interface IInventory
{
    [Index(0)]
    public int UltimateAttacks { get; set; }
    [Index(1)]
    public int SpecialAttacks { get; set; }
    [Index(2)]
    public int Dodges { get; set; }
}