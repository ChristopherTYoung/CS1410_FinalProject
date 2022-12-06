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
        Player testPlayer = new Player();
        try
        {
            testPlayer = Game.SelectClass("asldfj", "Chris");
        }
        catch (Exception)
        {
            Assert.AreEqual(0, testPlayer.Damage);
            Assert.AreEqual(0, testPlayer.Defense);
        }

    }

    [Test]
    public void TestPlayerAttack()
    {
        Player player = new Knight("Chris");
        Enemy enemy = new SkeletonKnight();
        Assert.True(Game.PlayerTurn(player, enemy, "Normal") >= 2);
    }
    [Test]
    public void TestPlayerAttack2()
    {
        Player player = new Knight("Chris");
        Enemy enemy = new SkeletonKnight();
        Assert.True(Game.PlayerTurn(player, enemy, "Special") >= 4);
    }
    [Test]
    public void TestPlayerAttack3()
    {
        Player player = new Knight("Chris");
        Enemy enemy = new SkeletonKnight();
        Assert.True(Game.PlayerTurn(player, enemy, "Ultimate") >= 6);
    }
    [Test]
    public void TestDodge()
    {
        Player player = new Knight("Chris");
        Enemy enemy = new SkeletonKnight();
        Assert.True(Game.PlayerTurn(player, enemy, "Dodge") == 0);
    }
    [Test]
    public void PlayersDamageIsTooLow()
    {
        Player player = new Archer("Chris");
        Enemy enemy = new SkeletonKnight();
        Assert.AreEqual(14, Game.PlayerTurn(player, enemy, "Normal"));
    }
}