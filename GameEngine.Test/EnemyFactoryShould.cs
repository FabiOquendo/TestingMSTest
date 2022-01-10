using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GameEngine.Test
{
    [TestClass]
    public class EnemyFactoryShould
    {
        [TestMethod]
        public void NotAllowNullName()
        {
            // Arrange
            EnemyFactory sut = new EnemyFactory();

            // Act


            // Assert
            Assert.ThrowsException<ArgumentNullException>(() => sut.Create(null));
        }

        [TestMethod]
        public void OnlyAllowKingOrQueenBossEnmies()
        {
            // Arrange
            EnemyFactory sut = new EnemyFactory();

            // Act


            // Assert
            EnemyCreationException ex = Assert.ThrowsException<EnemyCreationException>(() => sut.Create("Zombie", true));
            Assert.AreEqual("Zombie", ex.RequestedEnemyName);
        }

        [TestMethod]
        public void CreateNormalEnemyByDefault()
        {
            // Arrange
            EnemyFactory sut = new EnemyFactory();

            // Act
            Enemy enemy = sut.Create("Zombie");

            // Assert
            Assert.IsInstanceOfType(enemy, typeof(NormalEnemy));
        }

        [TestMethod]
        public void CreateBossEnemy()
        {
            // Arrange
            EnemyFactory sut = new EnemyFactory();

            // Act
            Enemy enemy = sut.Create("Zombie King", true);

            // Assert
            Assert.IsInstanceOfType(enemy, typeof(BossEnemy));
        }

        [TestMethod]
        public void CreateSeparateInstances()
        {
            // Arrange
            EnemyFactory sut = new EnemyFactory();

            // Act
            Enemy enemy1 = sut.Create("Zombie");
            Enemy enemy2 = sut.Create("Zombie");

            // Assert
            Assert.AreNotSame(enemy1, enemy2);
        }
    }
}
