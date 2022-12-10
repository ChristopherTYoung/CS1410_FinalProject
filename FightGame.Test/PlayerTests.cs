
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
    public void CanCreatePlayer2()
    {
        Player testPlayer = Game.SelectClass("Knight", "Happy");

        Assert.AreEqual(17, testPlayer.Damage);
        Assert.AreEqual(20, testPlayer.Defense);
        Assert.AreEqual("Happy", testPlayer.Name);
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
    public void CanReadPlayerDataFromFiles()
    {
        var dir = Path.GetDirectoryName(typeof(Inventory).Assembly.Location);
        var newdir = Path.Combine(dir, "../../../../Players");
        Environment.CurrentDirectory = newdir;
        PlayerFileService file = new PlayerFileService();
        var player = file.ReadPlayerSavedData("Bobby");

        Assert.AreEqual(14, player.Damage);
        Assert.AreEqual(10, player.Defense);
        Assert.AreEqual("Bobby", player.Name);
    }

    [Test]
    public void CanReadInventoryDataFromFiles()
    {
        var dir = Path.GetDirectoryName(typeof(Player).Assembly.Location);
        var newdir = Path.Combine(dir, "../../../../Players");
        Environment.CurrentDirectory = newdir;
        PlayerFileService file = new PlayerFileService();
        var inventory = PlayerFileService.ReadInventorySavedData("Bobby");

        Assert.AreEqual(1, inventory.UltimateAttacks);
        Assert.AreEqual(3, inventory.SpecialAttacks);
        Assert.AreEqual(1, inventory.Dodges);
    }
    
    [Test]
    public void CanReadScoreDataFromFiles()
    {
        var dir = Path.GetDirectoryName(typeof(Score<string, int>).Assembly.Location);
        var newdir = Path.Combine(dir, "../../../../Players");
        Environment.CurrentDirectory = newdir;
        PlayerFileService file = new PlayerFileService();
        var score = file.ReadPlayerScoresFromFile("Bobby");

        Assert.AreEqual(0, score.EnemiesKilled);
        Assert.AreEqual(0, score.Money);
        Assert.AreEqual("Bobby", score.NameOfPlayer);
    }

    // [Test]
    // public void PlayersUseShopItems()
    // {
    //     //health is larger
    //     IInventory inventory = new Inventory();
    //     List<string> ItemsBought = new List<string>() { "Health Boost" };
    //     Player player = new Archer("Chris");
    //     Enemy enemy = new SkeletonKnight();
    //     var newHealth = Game.BuyItem("HealthBoost");
    //     Assert.AreEqual(player.Health + 2, BuyItem("HealthBoost"));
    // }
}