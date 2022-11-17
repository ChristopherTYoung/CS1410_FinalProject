﻿
public class Player
{
    protected string Name { get; init; }
    protected int Damage { get; init; }
    protected int Defense { get; init; }
    protected string? Description { get; init; }
    protected string? Weapon { get; init; }

    public override string ToString()
    {
        return $"Username: {Name} Damage: {Damage} Defense: {Defense} Weapon: {Weapon}";
    }

}
