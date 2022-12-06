
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
    public static int PlayerTurn(IPlayer player, Enemy enemy, string input, List<string> ItemsBought)
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
            if (move == Player.Moves.Special && Inventory.SpecialAttacks > 0)
            {
                Inventory.SpecialAttacks -= 1;
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
            else if (move == Player.Moves.Special && Inventory.SpecialAttacks == 0)
            {
                "You don't have any special attacks".PrintEachLetter();
                throw new Exception();
            }
            else if (move == Player.Moves.Ultimate && Inventory.UltimateAttacks > 0)
            {
                Inventory.UltimateAttacks -= 1;
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
            else if (move == Player.Moves.Ultimate && Inventory.UltimateAttacks == 0)
            {
                "You don't have any ultimate attacks".PrintEachLetter();
                throw new Exception();
            }
            else if (move == Player.Moves.Dodge)
                return 0;
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
            return 0;
        return 0;
    }
    int Gold = 0;
    public static void Round(IPlayer player, List<string> ItemsBought)
    {
        Game game = new Game();
        System.Console.WriteLine(player.Name);

        var enemy = Enemy.GetEnemy();

        var enemyHealth = enemy.Health;
        var playerHealth = player.Health;
        var roundIsStillGoing = true;
        var playerWins = true;

        System.Console.WriteLine($"You are fighting {enemy.Name}");

        while (roundIsStillGoing)
        {
            System.Console.WriteLine("Make your move (Dodge, Heal, Normal, Special, Ultimate");
            var input = Console.ReadLine();
            var damage = PlayerTurn(player, enemy, input, ItemsBought);
            System.Console.WriteLine(damage);
            enemyHealth -= damage;
            System.Console.WriteLine($"Player Health: {playerHealth} | Enemy Health: {enemyHealth}");

            if (enemyHealth <= 0)
            {
                player.Money = player.Money + 5;
                playerWins = true;
                roundIsStillGoing = false;
                Shop(player.Money);
            }

            var enemydamage = EnemyAttack(player, enemy);
            System.Console.WriteLine(enemydamage);
            playerHealth -= enemydamage;
            System.Console.WriteLine($"Player Health: {playerHealth} | Enemy Health: {enemyHealth}");
            if (playerHealth <= 0)
            {

                playerWins = false;
                roundIsStillGoing = false;
            }
        }
        if (playerWins)
        {
            System.Console.WriteLine("Player won");
        }
        else if (playerWins == false)
        {
            "Game Over".PrintEachLetter();
            "Select a class".PrintEachLetter();
            var input = Console.ReadLine();

            SelectClass(input!, player.Name);
        }
    }

    public static List<string> Shop(int Gold)
    {
        "Welcome to the Shop".PrintEachLetter();
        "We have quite a selection for you to choose from".PrintEachLetter();
        "We have health and dodge potions, you can also upgrade your abilities".PrintEachLetter();
        "What would you like to buy".PrintEachLetter();
        List<string> ItemsBought = new List<string>();
        var input = Console.ReadLine();
        if (input == "Attack Boost" && Gold >= 10)
        {
            Gold -= 10;
            ItemsBought.Add("AttackBoost");
            // Player NewPlayerDamage = inputClass.Damage +  2;
        }

        if (input == "HealthBoost")
        {
            Gold -= 5;
            ItemsBought.Add("Health Boost");
        }
        if (input == "DodgePotion")
        {
            Gold -= 5;
            ItemsBought.Add("Dodge Potion");
        }
        if (input == "Attack Potion")
        {
            Gold -= 5;
            ItemsBought.Add("AttackPotion");
        }
        //Make items a base value. Enemy will drop 10 gold each. After each encounter of the shop both enemy gold and Shop prices increase by 1/4 their original.
        //Potions will be 10 gold each (base value), upgrades will be (20 base value)

        return ItemsBought;
    }
}