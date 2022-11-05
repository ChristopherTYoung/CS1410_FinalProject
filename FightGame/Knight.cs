
public class Knight : Character
{
    public Knight(int damage, int defense)
    {
        if (damage <= 17)
            Damage = damage;
        else
        {
            Damage = 0;
            System.Console.WriteLine("Not a valid damage amount");
        }
        if (defense <= 20)
            Defense = defense;
        else
        {
            Damage = 0;
            System.Console.WriteLine("Not a valid defense amount");
        }

        AttackSpeed = 1;
        Weapon = "Greatsword";
        Description = "The Knight wears heavy armor and uses a greatsword. He can have incredible defense and damage, but due to his heavy armor his attack speed is slow. Starts out with a few healing potions";
    }
}