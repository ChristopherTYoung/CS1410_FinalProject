namespace FightGame.Test;

public class EnemyTests
{
    [Test]
    public void CanMakeEnemy()
    {
        bool expectedResult = true;
        Enemy CurrentEnemy = Enemy.GetEnemy();
        if (CurrentEnemy == new SkeletonKnight())
        {
            Assert.AreEqual(expectedResult, true);
        }
        else if (CurrentEnemy == new LichKing())
        {
             Assert.AreEqual(expectedResult, true);
        }
        else if (CurrentEnemy == new SpearUser())
        {
             Assert.AreEqual(expectedResult, true);
        }
        else if (CurrentEnemy == new Witch())
        {
             Assert.AreEqual(expectedResult, true);
        }
    }

    [Test]
    public void CanGetSpecificEnemyDamage()
    {
        Enemy CurrentEnemy = new SpearUser();
        Assert.AreEqual(CurrentEnemy.Damage, new SpearUser().Damage);
    }

    [Test]
    public void ListContainsShopItem()
    {
        Enemy CurrentEnemy = new SpearUser();
        Assert.AreEqual(CurrentEnemy.Damage, new SpearUser().Damage);
    }

    [Test]
    public void EnemyDoesDamage()
    {
        IInventory inventory = new Inventory();
        List<string> ItemsBought = new List<string>();
        Player player = new Archer("Chris");
        Enemy enemy = new SkeletonKnight();
        Assert.True(player.Health <= Game.PlayerTurn(player, enemy, "Normal", ItemsBought, inventory));
    }

    [Test]
    public void EnemyDoesNoDamage()
    {
          IInventory inventory = new Inventory();
        List<string> ItemsBought = new List<string>();
        Player player = new Archer("Chris");
        Enemy enemy = new SkeletonKnight();
        var playerHealth = Game.PlayerTurn(player, enemy, "Normal", ItemsBought, inventory);
        Assert.True(playerHealth == 100);
    }
}