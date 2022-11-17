
public static class CricitcalDamage
{
    public static int CriticalHit(this Random random, int damage) => damage + random.Next(damage);
    public static bool CritChance(this Random random, double chance = 0.7) => random.NextDouble() <= chance;
}