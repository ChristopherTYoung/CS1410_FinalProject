
public class Samurai : Player
{
    public Samurai(string name)
    {
        Name = name;
        Damage = 13;
        Defense = 17;
        Health = 100;
        
        Weapon = "Katana";
        Description = "The samurai wears heavy armor, but it is not as heavy as the knight's armor. The samurai wields a katana and starts with a few healing potions.";
        
    }
}