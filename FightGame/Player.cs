
public class Player
{
    public string Name { get; init; }
    public int Damage { get; init; }
    public int Defense { get; init; }
    public int Health { get; init; } = 100;
    public string? Description { get; init; }
    public string? Weapon { get; init; }
    public int UltimateAttacks { get; set; } = 1;
    public int SpecialAttacks { get; set; } = 3;
    public enum Moves
    {
        Normal = 1,
        Dodge = 0,
        Special = 2,
        Ultimate = 3,
    }

    public override string ToString()
    {
        return $"Username: {Name} Damage: {Damage} Defense: {Defense} Weapon: {Weapon}";
    }

}
