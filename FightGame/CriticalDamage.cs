
public static class CricitcalDamage
{
    /// <summary>
    /// CriticalHit will determine how much crit damage a player will do when he lands a critical hit.
    /// It can range anywhere from 1 to the players damage.
    /// </summary>
    public static int CriticalHit(this Random random, int damage) => damage + random.Next(damage);
    /// <summary>
    /// CritChance will determine whether or not the player lands a critical hit.
    /// </summary>
    public static bool CritChance(this Random random, double chance = 0.7) => random.NextDouble() <= chance;
}