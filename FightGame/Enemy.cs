public abstract class Enemy
{
    protected string? Name { get; init; }
    protected int Damage { get; init; }
    protected int Defense { get; init; }
    protected int Health { get; init; }
    protected string? Weapon { get; init; }


    // Enemy fought will be randomly generated? Possiably
    //Random generator = GenerateRandom()
    //1 = SkeletonKnight, 2 = LichKing, 3 = SpearUser, 4 = Witch
    public Enemy()
    {

    }

    // Enemy will do a random attack based on a random generator, goes with the damage prop, could crit.

}