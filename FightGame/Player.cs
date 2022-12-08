global using CsvHelper.Configuration.Attributes;
public class Player : IPlayer
{
    [Index(0)]
    public string Name { get; init; }
    [Index(1)]
    public int Damage { get; init; }
    [Index(2)]
    public int Defense { get; init; }
    [Index(3)]
    public int Health { get; init; }
    [Index(4)]
    public string? Description { get; init; }
    [Index(5)]
    public string? Weapon { get; init; }
    [Index(6)]
    public int Money { get; set; }
    public enum Moves
    {
        Normal = 1,
        Dodge = 0,
        Heal = 0,
        Special = 2,
        Ultimate = 3,
    }

    public override string ToString()
    {
        return $"Username: {Name} Damage: {Damage} Defense: {Defense} Weapon: {Weapon}";
    }

}
