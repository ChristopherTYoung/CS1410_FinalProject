public class Assassin : Player
{
    public Assassin(string name)
    {
        Name = name;
        Damage = 12;
        Defense = 12;

        Weapon = "Throwing Knives";
        Description = "The assassin uses knives that can be used as throwing knives. The assassin has incredible speed that allows him to eliminate enemies fast and efficiently. Starts out with a few healing potions";
    }
}