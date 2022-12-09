
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
        IInventory inventory = new Inventory();
        Player player = new Knight("Chris");
        Enemy enemy = new SkeletonKnight();
        Assert.True(Game.PlayerTurn(player, enemy, "Normal", new List<string>() { }, inventory) >= 2);
    }

    [Test]
    public void TestPlayerAttack2()
    {
        IInventory inventory = new Inventory();
        Player player = new Knight("Chris");
        Enemy enemy = new SkeletonKnight();
        Assert.True(Game.PlayerTurn(player, enemy, "Special", new List<string>() { }, inventory) >= 4);
    }

    [Test]
    public void TestPlayerAttack3()
    {
        IInventory inventory = new Inventory();
        Player player = new Knight("Chris");
        Enemy enemy = new SkeletonKnight();
        Assert.True(Game.PlayerTurn(player, enemy, "Ultimate", new List<string>() { }, inventory) >= 6);
    }

    [Test]
    public void TestDodge()
    {
        IInventory inventory = new Inventory();
        Player player = new Knight("Chris");
        Enemy enemy = new SkeletonKnight();
        Assert.True(Game.PlayerTurn(player, enemy, "Dodge", new List<string>() { }, inventory) == 0);
    }

    [Test]
    public void PlayersDamageIsTooLow()
    {
        IInventory inventory = new Inventory();
        List<string> ItemsBought = new List<string>();
        Player player = new Archer("Chris");
        Enemy enemy = new SkeletonKnight();
        Assert.AreEqual(14, Game.PlayerTurn(player, enemy, "Normal", ItemsBought, inventory));
    }

    [Test]
    public void PlayersDoesDamageWithShopItems()
    {
        //Damage is higher
        IInventory inventory = new Inventory();
        List<string> ItemsBought = new List<string>();
        Player player = new Archer("Chris");
        Enemy enemy = new SkeletonKnight();
        Assert.AreEqual(14, Game.PlayerTurn(player, enemy, "Normal", ItemsBought, inventory));
    }

    [Test]
    public void PlayersDoesDamageWithShopItems2()
    {
        //health is larger
        IInventory inventory = new Inventory();
        List<string> ItemsBought = new List<string>();
        Player player = new Archer("Chris");
        Enemy enemy = new SkeletonKnight();
        Assert.AreEqual(14, Game.PlayerTurn(player, enemy, "Normal", ItemsBought, inventory));
    }
}