public class Mage : Player
{
    public Mage(string name)
    {
        Name = name;
        Damage = 19;
        Defense = 9;
        Health = 100;
        
        Weapon = "Spellbook";
        Description = "The mage can learn many different powerful spells. His defense is weak, but he can do a high amount of damage. He starts out with a spellbook and a few healing potions.";
    }
}