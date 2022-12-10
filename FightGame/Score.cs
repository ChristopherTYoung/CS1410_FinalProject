//REQUIREMENT #10 - definition of our own generic datatype
// This is the score class where we keep track of player scores
public class Score<N, T> : IScore<N, T>
{
    [Index(0)]
    public N NameOfPlayer { get; set; }
    [Index(1)]
    public T EnemiesKilled { get; set; }
    [Index(2)]
    public T Money { get; set; }
    public Score()
    {

    }
    public override string ToString()
    {
        return $"Enemies Killed: {EnemiesKilled} | Money: {Money}";
    }
}