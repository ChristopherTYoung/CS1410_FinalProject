public class Warrior : Player
{
    public Warrior(string name)
    {
        Name = name;
        Damage = 16;
        Defense = 10;
        Health = 100;
        Weapon = "Sharp Sword";
        Description = "The warrior wields a sharp sword. He does a good amount of damage and has a good attack speed, but he has a weaker defense. Starts out with a few healing potions";
    }
}