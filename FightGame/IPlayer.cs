//REQUIREMENT #13 - an Interface
// We use an interface here. Our player class inherits from IPlayer
// We user IPlayer when we are reading and writing to files
public interface IPlayer
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
}