public class Archer : Character
{
    public Archer(int damage, int defense)
    {
        if (damage <= 14)
            Damage = damage;
        else
        {
            Damage = 0;
            System.Console.WriteLine("Not a valid damage amount");
        }
        if (defense <= 10)
            Defense = defense;
        else
        {
            Defense = 0;
            System.Console.WriteLine("Not a valid defense amount");
        }

        AttackSpeed = 3;
        Weapon = "Bow";
        Description = "The archer starts with a bow, a few arrows, a hunting knife, and a few healing potions. He has a good attack speed, but doesn't have great defense";
    }
}