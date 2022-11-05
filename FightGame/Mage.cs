public class Mage : Character
{
    public Mage(int damage, int defense)
    {
        if (damage <= 19)
            Damage = damage;
        else
        {
            Damage = 0;
            System.Console.WriteLine("Not a valid damage amount");
        }

        if (defense <= 9)
            Defense = defense;
        else
        {
            Defense = 0;
            System.Console.WriteLine("Not a valid defense amount");
        }

        AttackSpeed = 3;
        Weapon = "Spellbook";
        Description = "The mage can learn many different powerful spells. His defense is weak, but he can do a high amount of damage. He starts out with a spellbook and a few healing potions.";
    }
}