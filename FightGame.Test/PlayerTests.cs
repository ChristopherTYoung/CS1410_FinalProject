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

        Assert.True(testPlayer == null);
    }
    [Test]
    public void CanDoCritDamage()
    {
        
    }
}