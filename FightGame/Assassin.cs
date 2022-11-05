public class Assassin : Character
{
    public Assassin(int damage, int defense)
    {
        if (damage <= 12)
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
            Defense = 0;
            System.Console.WriteLine("Not a valid defense amount");
        }

        AttackSpeed = 4;
        Weapon = "Throwing Knives";
        Description = "The assassin uses knives that can be used as throwing knives. The assassin has incredible speed that allows him to eliminate enemies fast and efficiently. Starts out with a few healing potions";
    }
}