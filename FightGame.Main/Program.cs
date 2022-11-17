// See https://aka.ms/new-console-template for more information
public class Program
{
    static void Main()
    {
        "Welcome to FightGame.".PrintEachLetter();
        "What will your username be?".PrintEachLetter();

        var inputName = Console.ReadLine();

        "Select your class".PrintEachLetter();
        var inputClass = Console.ReadLine();

        Player player = Game.SelectClass(inputClass!, inputName!);

        Game.PlayerAttack(10);
    }
}