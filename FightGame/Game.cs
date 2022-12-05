
public class Game
{
    public Player player = new Player();

    public static void MainMenu()
    {
        PlayerFileService file = new PlayerFileService();
        var game = new Game();
        IPlayer player = new Player();
        "Welcome to Fight Game".PrintEachLetter();
        "Create a username or if you already have one enter your username".PrintEachLetter();
        var inputName = Console.ReadLine();
        if (File.Exists($"../Players/{inputName}.csv"))
        {
            player = file.ReadPlayerSavedData(inputName!);
            System.Console.WriteLine(player);
        }
        else
        {
            "Select a class".PrintEachLetter();
            var inputClass = Console.ReadLine();
            player = SelectClass(inputClass!, inputName!);
        }
        Inventory inventory = new Inventory();
        var gameIsStillGoing = true;
        while (gameIsStillGoing)
        {
            System.Console.WriteLine("| Play\n| Quit");
            var input = Console.ReadLine();

            if (input == "Play")
                Round(player);
            else if (input == "Quit")
            {
                file.WritePlayerSavedData(player);
                // PlayerFileService.WriteInventorySavedData(player.Name, inventory);
                gameIsStillGoing = false;
            }
            else
                System.Console.WriteLine("Not a valid option. Try again");
        }

    }
    public static Player SelectClass(string inputClass, string inputName)
    {
        Game game = new Game();
        Player player = new Player();
        try
        {
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
            player.ToString().PrintEachLetter();
        }
        catch (Exception)
        {
            "Not a valid class type. Try again".PrintEachLetter();
            "Select your class".PrintEachLetter();
            var input = Console.ReadLine();
            return SelectClass(input!, inputName);
        }

        return player;
    }
    public static int PlayerTurn(IPlayer player, Enemy enemy)
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
                {
                    return ((player.Damage - enemy.Defense) * (int)move) + rnd.CriticalHit(player.Damage);
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
            return PlayerTurn(player, enemy);
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
    public static void Round(IPlayer player)
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
            var damage = PlayerTurn(player, enemy);
            System.Console.WriteLine(damage);
            enemyHealth -= damage;
            System.Console.WriteLine($"Player Health: {playerHealth} | Enemy Health: {enemyHealth}");

            if (enemyHealth <= 0)
            {
                Player.Money = Player.Money + 5;
                playerWins = true;
                roundIsStillGoing = false;
                Shop(Player.Money);
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

            SelectClass(input!, game.player.Name);
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
        if(input == "Attack Boost" && Gold >= 10)
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