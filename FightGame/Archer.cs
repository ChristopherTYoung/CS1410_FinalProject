//REQUIREMENT #6 inheritance - Character Types inherit from Player.
//The Players stats will be set appropriately based on what Character Type they choose.
public class Archer : Player
{
    public Archer(string name)
    {
        Name = name;
        Damage = 14;
        Defense = 10;
        Health = 100;
        Weapon = "Bow";
        Description = "The archer starts with a bow, a few arrows, a hunting knife, and a few healing potions. He has a good attack speed, but doesn't have great defense";
    }
}