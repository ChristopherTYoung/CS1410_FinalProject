public class Warrior : Character
{
    public Warrior(int damage, int defense)
    {
        if (damage <= 16)
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
            Damage = 0;
            System.Console.WriteLine("Not a valid defense amount");
        }

        Weapon = "Sharp Sword";
        AttackSpeed = 3;
        Description = "The warrior wields a sharp sword. He does a good amount of damage and has a good attack speed, but he has a weaker defense. Starts out with a few healing potions";
    }
}