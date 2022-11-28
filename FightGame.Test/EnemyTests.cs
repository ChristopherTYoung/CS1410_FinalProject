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
}