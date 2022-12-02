
public class Game
{
    public Player player = new Player();

    public static void MainMenu()
    {
        "Welcome to Fight Game".PrintEachLetter();
        "Create a username or if you already have one enter your username".PrintEachLetter();
        var inputName = Console.ReadLine();
        "Select a class".PrintEachLetter();
        var inputClass = Console.ReadLine();
        SelectClass(inputClass, inputName);

    }
    public static Player SelectClass(string inputClass, string inputName)
    {
        Game game = new Game();

        try
        {
            game.player = inputClass switch
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
            game.player.ToString().PrintEachLetter();
        }
        catch (Exception)
        {
            "Not a valid class type. Try again".PrintEachLetter();
            "Select your class".PrintEachLetter();
            var input = Console.ReadLine();
            return SelectClass(input, inputName);
        }

        return game.player;
    }
    public static int PlayerTurn(Player player, Enemy enemy)
    {
        Random rnd = new Random();
        var doesCrit = rnd.CritChance();
        try
        {
            System.Console.WriteLine("Make your move (Dodge, Normal, Special, Ultimate)");
            var input = Console.ReadLine();
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
                if (player.Damage > enemy.Defense && doesCrit)
                    return ((player.Damage - enemy.Defense) * (int)move) + rnd.CriticalHit(player.Damage);
                else if (player.Damage > enemy.Defense && doesCrit == false)
                    return ((player.Damage - enemy.Defense) * (int)move);
                else
                    return player.Damage;
            }
            else if (move == Player.Moves.Special && Inventory.SpecialAttacks == 0)
            {
                "You don't have any special attacks".PrintEachLetter();
                return PlayerTurn(player, enemy);
            }
            else if (move == Player.Moves.Ultimate && Inventory.UltimateAttacks > 0)
            {
                Inventory.UltimateAttacks -= 1;
                if (player.Damage > enemy.Defense && doesCrit)
                    return ((player.Damage - enemy.Defense) * (int)move) + rnd.CriticalHit(player.Damage);
                else if (player.Damage > enemy.Defense && doesCrit == false)
                    return ((player.Damage - enemy.Defense) * (int)move);
                else
                    return player.Damage;
            }
            else if (move == Player.Moves.Ultimate && Inventory.UltimateAttacks == 0)
            {
                "You don't have any ultimate attacks".PrintEachLetter();
                return PlayerTurn(player, enemy);
            }
            else if (move == Player.Moves.Dodge)
                return 0;
            else
            {
                if (player.Damage > enemy.Defense && doesCrit)
                    return ((player.Damage- enemy.Defense) * (int)move) + rnd.CriticalHit(player.Damage) ;
                else if (player.Damage > enemy.Defense && doesCrit == false)
                    return ((player.Damage - enemy.Defense) * (int)move);
                else
                    return player.Damage;
            }
        }
        catch (Exception)
        {
            System.Console.WriteLine("Not a valid move. Try again");
            return PlayerTurn(player, enemy);
        }

    }

    public static int EnemyAttack(int damage)
    {
        int damageDone;
        Random rnd = new Random();
        var doesCrit = rnd.CritChance();

        if (doesCrit)
            return damageDone = rnd.CriticalHit(damage);
        else
            return damageDone = damage;
    }

    public static void Round(Player player, Enemy enemy)
    {
        enemy = Enemy.GetEnemy();
        var enemyHealth = enemy.Health;
        var playerHealth = player.Health;
        var roundIsStillGoing = true;
        while (roundIsStillGoing)
        {
            var damage = PlayerTurn(player, enemy);
            enemyHealth -= damage;

            if (playerHealth <= 0 || enemyHealth <= 0)
                roundIsStillGoing = false;
        }
    }

    public static List<string> Shop()
    {
        return new List<string> { };
    }
}