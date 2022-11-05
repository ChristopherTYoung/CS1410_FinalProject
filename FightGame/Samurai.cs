
public class Samurai : Character
{
    public Samurai(int damage, int defense)
    {
        if (damage <= 13)
            Damage = damage;
        else
        {
            Damage = 0;
            System.Console.WriteLine("Not a valid damage amount");
        }
        if (defense <= 17)
            Defense = defense;
        else
        {
            Damage = 0;
            System.Console.WriteLine("Not a valid defense amount");
        }

        Weapon = "Katana";
        AttackSpeed = 2;
        Description = "The samurai wears heavy armor, but it is not as heavy as the knight's armor. The samurai wields a katana and starts with a few healing potions.";
    }
}