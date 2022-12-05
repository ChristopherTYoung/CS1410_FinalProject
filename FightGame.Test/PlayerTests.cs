namespace FightGame.Test;

public class PlayerTests
{
    [Test]
    public void CanCreatePlayer()
    {
        Player testPlayer = Game.SelectClass("Archer", "Chris");

        Assert.AreEqual(14, testPlayer.Damage);
        Assert.AreEqual(10, testPlayer.Defense);
        Assert.AreEqual("Chris", testPlayer.Name);
    }

    [Test]
    public void ClassExceptionIsThrow()
    {
        Player testPlayer = Game.SelectClass("asldfj", "Chris");
    }

    [Test]
    public void CanDoCritDamage()
    {
        Player player = new Archer("Chris");

    }

    [Test]
    public void PlayersDamageIsTooLow()
    {
        Player player = new Archer("Chris");
        Enemy enemy = new SkeletonKnight();
        Assert.AreEqual(14, Game.PlayerTurn(player, enemy, "Normal"));
    }
}