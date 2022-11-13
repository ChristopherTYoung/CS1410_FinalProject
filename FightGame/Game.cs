
public class Game
{
    public Player selectedClass;
    public static Player SelectClass(string inputClass, string inputName)
    {
        Game game = new Game();

        try
        {
            game.selectedClass = inputClass switch
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
            game.selectedClass.ToString().PrintEachLetter();
        }
        catch (Exception InvalidInput)
        {
            "Not a valid class type. Try again".PrintEachLetter();

        }


        return game.selectedClass;
    }
}