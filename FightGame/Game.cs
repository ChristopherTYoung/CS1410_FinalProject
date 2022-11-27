
public class Game
{
    public Player player = new Player();
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
        catch (Exception e)
        {
            "Not a valid class type. Try again".PrintEachLetter();
            "Select your class".PrintEachLetter();
            return null;
            // var userInput = Console.ReadLine();
            // SelectClass(userInput!, inputName);
            // System.Console.WriteLine(game.player);
        }

        return game.player;
    }
    public static int PlayerAttack(int damage)
    {
        int damageDone;
        Random rnd = new Random();
        var doesCrit = rnd.CritChance();

        if(doesCrit)
            return damageDone = rnd.CriticalHit(damage);
        else
            return damageDone = damage;
    }
    public static void Round(Player player, Enemy enemy)
    {
        var gameIsStillGoing = true;
        while(gameIsStillGoing)
        {
            System.Console.WriteLine("Choose your attack");
            var input = Console.ReadLine();
            

        }
    }
}