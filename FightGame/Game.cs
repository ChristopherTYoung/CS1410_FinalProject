
// REQUIREMENT 1 a Class Definition
public class Game
{
    /// <summary>
    /// SelectClass will take in an input class and name. This is where the user chooses a Character Type. If the class is not valid, it will throw an exception
    /// </summary>
    //REQUIREMENT #12 - a Static Member Function
    public static Player SelectClass(string inputClass, string inputName)
    {
        Game game = new Game();
        Player player = new Player();
        player = inputClass switch
        {
            "Archer" => new Archer(inputName),
            "Assassin" => new Assassin(inputName),
            "Executioner" => new Executioner(inputName),
            "Knight" => new Knight(inputName),
            "Mage" => new Mage(inputName),
            "Samurai" => new Samurai(inputName),
            "Summoner" => new Summoner(inputName),
            "Warrior" => new Warrior(inputName),
            _ => throw new Exception()
        };
        return player;
    }
    /// <summary>
    /// PlayerTurn decides how much damage the player does based on their damage subtracting the enemy defense, their move, the critical hit damage, and attack boosts
    /// If their damage is too low, it will do the base damage without any critical damage, damage multipliers, or attack boosts
    /// </summary>
    public static int PlayerTurn(IPlayer player, Enemy enemy, string input, List<string> ItemsBought, IInventory inventory)
    {
        Random rnd = new Random();
        var doesCrit = rnd.CritChance();
        try
        {
            var move = input switch
            {
                "Dodge" => Player.Moves.Dodge,
                "Normal" => Player.Moves.Normal,
                "Special" => Player.Moves.Special,
                "Ultimate" => Player.Moves.Ultimate,
                _ => throw new Exception()
            };
            if (move == Player.Moves.Special && inventory.SpecialAttacks > 0)
            {
                inventory.SpecialAttacks -= 1;
                if (player.Damage > enemy.Defense && doesCrit && ItemsBought.Contains("Attack Boost"))
                {
                    return ((player.Damage - enemy.Defense) * (int)move) + rnd.CriticalHit(player.Damage) + 2;
                }
                else if (player.Damage > enemy.Defense && doesCrit)
                {
                    return ((player.Damage - enemy.Defense) * (int)move) + rnd.CriticalHit(player.Damage);
                }
                else if (player.Damage > enemy.Defense && doesCrit == false && ItemsBought.Contains("Attack Boost"))
                {
                    return ((player.Damage - enemy.Defense) * (int)move) + 2;
                }
                else if (player.Damage > enemy.Defense && doesCrit == false)
                {
                    return ((player.Damage - enemy.Defense) * (int)move);
                }
                else
                {
                    return player.Damage;
                }
            }
            else if (move == Player.Moves.Special && inventory.SpecialAttacks == 0)
                throw new Exception();
            else if (move == Player.Moves.Ultimate && inventory.UltimateAttacks > 0)
            {
                inventory.UltimateAttacks -= 1;
                if (player.Damage > enemy.Defense && doesCrit && ItemsBought.Contains("Attack Boost"))
                    return ((player.Damage - enemy.Defense) * (int)move) + rnd.CriticalHit(player.Damage) + 2;
                else if (player.Damage > enemy.Defense && doesCrit)
                    return ((player.Damage - enemy.Defense) * (int)move) + rnd.CriticalHit(player.Damage);
                else if (player.Damage > enemy.Defense && doesCrit == false && ItemsBought.Contains("Attack Boost"))
                    return ((player.Damage - enemy.Defense) * (int)move) + 2;
                else if (player.Damage > enemy.Defense && doesCrit == false)
                    return ((player.Damage - enemy.Defense) * (int)move);
                else
                    return player.Damage;
            }
            else if (move == Player.Moves.Ultimate && inventory.UltimateAttacks == 0)
                throw new Exception();
            else if (move == Player.Moves.Dodge && inventory.Dodges > 0)
            {
                inventory.Dodges -= 1;
                return 0;
            }
            else if (move == Player.Moves.Dodge && inventory.Dodges == 0)
                throw new Exception();
            else
            {
                if (player.Damage > enemy.Defense && doesCrit && ItemsBought.Contains("Attack Boost"))
                    return ((player.Damage - enemy.Defense) * (int)move) + rnd.CriticalHit(player.Damage) + 2;
                else if (player.Damage > enemy.Defense && doesCrit)
                    return ((player.Damage - enemy.Defense) * (int)move) + rnd.CriticalHit(player.Damage);
                else if (player.Damage > enemy.Defense && doesCrit == false && ItemsBought.Contains("Attack Boost"))
                    return ((player.Damage - enemy.Defense) * (int)move) + 2;
                else if (player.Damage > enemy.Defense && doesCrit == false)
                    return ((player.Damage - enemy.Defense) * (int)move) + 2;
                else
                    return player.Damage;
            }
        }
        catch (Exception)
        {
            System.Console.WriteLine("Not a valid move. Try again");
            throw new Exception();
        }

    }

    /// <summary>
    /// EnemyAttack decides how much damage the enemy does based on their damage subtracting the player defense and the critical hit damage
    /// </summary>
    public static int EnemyAttack(IPlayer player, Enemy enemy)
    {
        Random rnd = new Random();
        var doesCrit = rnd.CritChance();

        if (enemy.Damage > player.Defense && doesCrit)
            return ((enemy.Damage - player.Defense) + rnd.CriticalHit(enemy.Damage));
        else if (enemy.Damage > player.Defense && doesCrit == false)
            return (enemy.Damage - player.Defense);
        else if (enemy.Damage < player.Defense)
            return enemy.Damage;
        return 0;
    }
}