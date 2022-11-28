public abstract class Enemy
{
    public string? Name { get; init; }
    public int Damage { get; init; }
    public int Defense { get; init; }
    public int Health { get; init; }
    public string? Weapon { get; init; }


    // Enemy fought will be randomly generated? Possiably
    //Random generator = GenerateRandom()
    //1 = SkeletonKnight, 2 = LichKing, 3 = SpearUser, 4 = Witch

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
    // Enemy will do a random attack based on a random generator, goes with the damage prop, could crit.

}