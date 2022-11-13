public class Summoner : Player
{
    public Summoner(string name)
    {
        Name = name;
        Damage = 18;
        Defense = 10;

        Weapon = "Summon Spellbook";
        Description = "The summoner also has a weak defense, but can summon powerful minions to fight for him. The summoner starts with a spellbook that has a few summons, and a few healing potions.";
    }
}