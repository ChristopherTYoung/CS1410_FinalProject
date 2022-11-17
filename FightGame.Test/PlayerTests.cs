namespace FightGame.Test;

public class PlayerTests
{
    [Test]
    public void CanCreatePlayer()
    {
        Player testPlayer = Game.SelectClass("Archer", "Chris");
    }
    [Test]
    public void ClassExceptionIsThrow()
    {

    }
}