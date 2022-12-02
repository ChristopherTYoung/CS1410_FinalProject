
public class Player
{
    public string Name { get; init; }
    public int Damage { get; init; }
    public int Defense { get; init; }
    public int Health { get; init; } = 100;
    public string? Description { get; init; }
    public string? Weapon { get; init; }
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
