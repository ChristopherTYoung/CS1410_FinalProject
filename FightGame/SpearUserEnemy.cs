public class SpearUser : Enemy
{
    public SpearUser(string name)
    {
        Name = "Uldyr The Spear Champ";
        Damage = 16;
        Defense = 8;
        // Increase dodge chance cause they are a bit more out of reach?
        Health = 100; //Could Change
    
        Weapon = "Spear";
    }
}