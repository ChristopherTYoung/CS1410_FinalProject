
public class Player
{
    public string Name { get; init; }
    public int Damage { get; init; }
    public int Defense { get; init; }
    public string? Description { get; init; }
    public string? Weapon { get; init; }

    public override string ToString()
    {
        return $"Username: {Name} Damage: {Damage} Defense: {Defense} Weapon: {Weapon}";
    }

}
