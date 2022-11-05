public class Summoner : Character
{
    public Summoner(int damage, int defense)
    {
        if (damage <= 18)
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

        Weapon = "Summon Spellbook";
        AttackSpeed = 3;
        Description = "The summoner also has a weak defense, but can summon powerful minions to fight for him. The summoner starts with a spellbook that has a few summons, and a few healing potions.";
    }
}