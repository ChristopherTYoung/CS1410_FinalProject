public interface IScore<N, T>
{
    [Index(0)]
    public N NameOfPlayer { get; set; }
    [Index(1)]
    public T EnemiesKilled { get; set; }
    [Index(2)]
    public T Money { get; set; }

}