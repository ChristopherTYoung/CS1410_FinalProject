
public class Executioner : Character
{
    public Executioner(int damage, int defense)
    {
        if (damage <= 15)
            Damage = damage;
        else
        {
            Damage = 0;
            System.Console.WriteLine("Not a valid damage amount");
        }
        if (defense <= 12)
            Defense = defense;
        else
        {
            Damage = 0;
            System.Console.WriteLine("Not a valid defense amount");
        }

        Weapon = "Executioner's Axe";
        AttackSpeed = 2;
        Description = "The executioner starts with an executioner's axe. He is able to use some forms of Dark Magic. Starts out with a few healing potions";
    }
}