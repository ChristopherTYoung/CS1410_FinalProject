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
        Assert.True(Game.PlayerTurn(player, enemy, "Normal", new List<string>() { }) >= 2);
    }
    
    [Test]
    public void TestPlayerAttack2()
    {
        Player player = new Knight("Chris");
        Enemy enemy = new SkeletonKnight();
        Assert.True(Game.PlayerTurn(player, enemy, "Special", new List<string>() { }) >= 4);
    }

    [Test]
    public void TestPlayerAttack3()
    {
        Player player = new Knight("Chris");
        Enemy enemy = new SkeletonKnight();
        Assert.True(Game.PlayerTurn(player, enemy, "Ultimate", new List<string>() { }) >= 6);
    }

    [Test]
    public void TestDodge()
    {
        Player player = new Knight("Chris");
        Enemy enemy = new SkeletonKnight();
        Assert.True(Game.PlayerTurn(player, enemy, "Dodge", new List<string>() { }) == 0);
    }

    [Test]
    public void PlayersDamageIsTooLow()
    {
        List<string> ItemsBought = new List<string>();
        Player player = new Archer("Chris");
        Enemy enemy = new SkeletonKnight();
        Assert.AreEqual(14, Game.PlayerTurn(player, enemy, "Normal", ItemsBought));
    }

    [Test]
    public void PlayersDoesDamageWithShopItems()
    {
        //Damage is higher
        List<string> ItemsBought = new List<string>();
        Player player = new Archer("Chris");
        Enemy enemy = new SkeletonKnight();
        Assert.AreEqual(14, Game.PlayerTurn(player, enemy, "Normal", ItemsBought));
    }

    [Test]
     public void PlayersDoesDamageWithShopItems2()
    {
        //health is larger
        List<string> ItemsBought = new List<string>();
        Player player = new Archer("Chris");
        Enemy enemy = new SkeletonKnight();
        Assert.AreEqual(14, Game.PlayerTurn(player, enemy, "Normal", ItemsBought));
    }
}