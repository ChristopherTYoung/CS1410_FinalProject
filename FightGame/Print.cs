
public static class Print
{
    public static void PrintEachLetter(this string text)
    {
        foreach(var letter in text)
        {
            System.Console.Write(letter);
            Thread.Sleep(10);
        }
        System.Console.WriteLine("");
    }
    
}