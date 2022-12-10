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
    public void EnemyDoesDamage()
    {
        IInventory inventory = new Inventory();
        List<string> ItemsBought = new List<string>();
        Player player = new Archer("Chris");
        Enemy enemy = new SkeletonKnight();
        Assert.True(Game.PlayerTurn(player, enemy, "Normal", ItemsBought, inventory) <= player.Health);
    }

    [Test]
    public void EnemyDoesBaseDamage()
    {
        IInventory inventory = new Inventory();
        List<string> ItemsBought = new List<string>();
        Player player = new Knight("Chris");
        Enemy enemy = new Witch();
        var DamageDone = Game.EnemyAttack(player, enemy);
        Assert.AreEqual(14, DamageDone);
    }

    [Test]
    public void EnemyDoesBaseDamage2()
    {
        IInventory inventory = new Inventory();
        List<string> ItemsBought = new List<string>();
        Player player = new Knight("Chris");
        Enemy enemy = new SkeletonKnight();
        var DamageDone = Game.EnemyAttack(player, enemy);
        Assert.AreEqual(15, DamageDone);
    }

    [Test]
    public void GetEnemyBaseDefense()
    {
        IInventory inventory = new Inventory();
        List<string> ItemsBought = new List<string>();
        Player player = new Knight("Chris");
        Enemy enemy = new SkeletonKnight();
        Assert.AreEqual(15, enemy.Defense);
    }
}