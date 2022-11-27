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
    public Enemy()
    {
    }

    public static string GetEnemy()
    {
        Random random = new Random(4);
        //string CurrentEnemy = random.Next();
        return "";
    }
    // Enemy will do a random attack based on a random generator, goes with the damage prop, could crit.

}