global using CsvHelper.Configuration.Attributes;

//REQUIREMENT #2 a Second Class Definition
// This is the player class, where we keep player attributes.
public class Player : IPlayer
{

    // REQUIREMENT #11 Properties
    // Player Attributes and Stats. Defense, Damage, Health, and Money
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
    //REQUIREMENT #5 - an Enumerated Type
    //These are the moves the player can choose from
    //They all have a damage multiplier
    //Dodge is set to 0 because it will do no damage to the enemy
    public enum Moves
    {
        Normal = 1,
        Dodge = 0,
        Special = 2,
        Ultimate = 3,
    }
    //REQUIREMENT #8 - A Second Example of Polymorphism
    //This overrides the ToString for the player so that we can display
    //players a certain way
    public override string ToString()
    {
        return $"Username: {Name} Damage: {Damage} Defense: {Defense} Weapon: {Weapon}";
    }

}
