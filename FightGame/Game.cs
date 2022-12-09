
public class Game
{

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
                if (player.Damage > enemy.Defense && doesCrit && ItemsBought.Contains("AttackBoost"))
                {
                    return ((player.Damage - enemy.Defense) * (int)move) + rnd.CriticalHit(player.Damage) + 2;
                }
                else if (player.Damage > enemy.Defense && doesCrit)
                {
                    return ((player.Damage - enemy.Defense) * (int)move) + rnd.CriticalHit(player.Damage);
                }
                else if (player.Damage > enemy.Defense && doesCrit == false && ItemsBought.Contains("AttackBoost"))
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
                if (player.Damage > enemy.Defense && doesCrit && ItemsBought.Contains("AttackBoost"))
                    return ((player.Damage - enemy.Defense) * (int)move) + rnd.CriticalHit(player.Damage) + 2;
                else if (player.Damage > enemy.Defense && doesCrit)
                    return ((player.Damage - enemy.Defense) * (int)move) + rnd.CriticalHit(player.Damage);
                else if (player.Damage > enemy.Defense && doesCrit == false && ItemsBought.Contains("AttackBoost"))
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
                if (player.Damage > enemy.Defense && doesCrit)
                    return ((player.Damage - enemy.Defense) * (int)move) + rnd.CriticalHit(player.Damage);
                else if (player.Damage > enemy.Defense && doesCrit == false)
                    return ((player.Damage - enemy.Defense) * (int)move);
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