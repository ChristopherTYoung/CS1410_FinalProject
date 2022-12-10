public abstract class Enemy
{
    public string? Name { get; init; }
    public int Damage { get; init; }
    public int Defense { get; init; }
    public int Health { get; init; }
    public string? Weapon { get; init; }


    // Enemy fought will be randomly generated
    /// <summary>
    /// GetEnemy will return a random enemy. The enemy chosen will be random each game.
    /// </summary>
    public static Enemy GetEnemy()
    {
        Random random = new Random();
        int Random_Enemy = random.Next(5);
        if (Random_Enemy == 1)
        {
            return new SkeletonKnight();
        }
        else if (Random_Enemy == 2)
        {
            return new LichKing();
        }
        else if (Random_Enemy == 3)
        {
            return new SpearUser();
        }
        else if (Random_Enemy == 4)
        {
            return new Witch();
        }
        return new SkeletonKnight();
    }
}