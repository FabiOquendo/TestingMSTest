using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace GameEngine.Test
{
    [TestClass]
    public class PlayerCharacterShould
    {
        public static IEnumerable<object[]> Damages
        {
            get
            {
                return new List<object[]>
                {
                    new object[] {0, 100},
                    new object[] {1, 99},
                    new object[] {50, 50},
                    new object[] {99, 1},
                    new object[] {100, 1},
                };
            }
        }

        public static IEnumerable<object[]> GetDamages()
        {
            return new List<object[]>
            {
                new object[] {0, 100},
                new object[] {1, 99},
                new object[] {50, 50},
                new object[] {98, 2},
                new object[] {100, 1},
            };
        }

        [TestMethod]
        [TestCategory("Player Default")]
        //[Ignore]
        public void BeInexperiencedWhenNew()
        {
            // Arrange
            PlayerCharacter sut;

            // Act
            sut = new PlayerCharacter();

            // Assert
            Assert.IsTrue(sut.IsNoob);
        }

        [TestMethod]
        [TestCategory("Player Default")]
        //[Ignore("Temporarily disable for refactoring")]
        public void NotHaveNickNameByDefault()
        {
            // Arrange
            PlayerCharacter sut;

            // Act
            sut = new PlayerCharacter();

            // Assert
            Assert.IsNull(sut.NickName);
        }

        [TestMethod]
        [TestCategory("Player Default")]
        public void StartWithDefaultHealth()
        {
            // Arrange
            PlayerCharacter sut;

            // Act
            sut = new PlayerCharacter();

            // Assert
            Assert.AreEqual(100, sut.Health);
        }

        [DataTestMethod]
        [DynamicData(nameof(ExternalHealthDamageTestData.TestData), typeof(ExternalHealthDamageTestData))]
        //[DynamicData(nameof(DamageData.GetDamages), typeof(DamageData), DynamicDataSourceType.Method)]
        //[DynamicData(nameof(GetDamages), DynamicDataSourceType.Method)]
        //[DynamicData(nameof(Damages))]
        //[DataRow(0, 100)]
        //[DataRow(1, 99)]
        //[DataRow(50, 50)]
        //[DataRow(100, 1)]
        [TestCategory("Player Heakth")]
        public void TakeDamage(int damage, int expectedHealth)
        {
            // Arrange
            PlayerCharacter sut = new PlayerCharacter();

            // Act
            sut.TakeDamage(damage);

            // Assert
            Assert.AreEqual(expectedHealth, sut.Health);
        }

        [TestMethod]
        [TestCategory("Player Heakth")]
        public void TakeDamage_NotEqual()
        {
            // Arrange
            PlayerCharacter sut = new PlayerCharacter();

            // Act
            sut.TakeDamage(1);

            // Assert
            Assert.AreNotEqual(100, sut.Health);
        }

        [TestMethod]
        [TestCategory("Player Heakth")]
        public void IncreaseHealthAfterSleeping()
        {
            // Arrange
            PlayerCharacter sut = new PlayerCharacter();

            // Act
            sut.Sleep();

            // Assert
            Assert.IsTrue(sut.Health >= 101 && sut.Health <= 200);
        }

        [TestMethod]
        [TestCategory("Player Name")]
        public void CalculateFullName()
        {
            // Arrange
            PlayerCharacter sut = new PlayerCharacter();

            // Act
            sut.FirstName = "Fabio";
            sut.LastName = "Oquendo";

            // Assert
            Assert.AreEqual("Fabio Oquendo", sut.FullName);
        }

        [TestMethod]
        [TestCategory("Player Name")]
        public void HaveFullNameStartingWithFirstName()
        {
            // Arrange
            PlayerCharacter sut = new PlayerCharacter();

            // Act
            sut.FirstName = "Fabio";
            sut.LastName = "Oquendo";

            // Assert
            StringAssert.StartsWith(sut.FullName, "Fabio");
        }

        [TestMethod]
        [TestCategory("Player Name")]
        public void HaveFullNameEndingWithFirstName()
        {
            // Arrange
            PlayerCharacter sut = new PlayerCharacter();

            // Act
            sut.FirstName = "Fabio";
            sut.LastName = "Oquendo";

            // Assert
            StringAssert.EndsWith(sut.FullName, "Oquendo");
        }

        [TestMethod]
        [TestCategory("Player Name")]
        public void CalculateFullName_SubstringAssertExample()
        {
            // Arrange
            PlayerCharacter sut = new PlayerCharacter();

            // Act
            sut.FirstName = "Fabio";
            sut.LastName = "Oquendo";

            // Assert
            StringAssert.Contains(sut.FullName, "io Oq");
        }

        [TestMethod]
        [TestCategory("Player Name")]
        public void CalculateFullNameWithTitleCase()
        {
            // Arrange
            PlayerCharacter sut = new PlayerCharacter();

            // Act
            sut.FirstName = "Fabio";
            sut.LastName = "Oquendo";

            // Assert
            StringAssert.Matches(sut.FullName, new Regex("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+"));
        }

        [TestMethod]
        [TestCategory("Player Weapons")]
        public void HaveALongBow()
        {
            // Arrange
            PlayerCharacter sut;

            // Act
            sut = new PlayerCharacter();

            // Assert
            CollectionAssert.Contains(sut.Weapons, "Long Bow");
        }

        [TestMethod]
        [TestCategory("Player Weapons")]
        public void NotHaveAStaffOfWonder()
        {
            // Arrange
            PlayerCharacter sut;

            // Act
            sut = new PlayerCharacter();

            // Assert
            CollectionAssert.DoesNotContain(sut.Weapons, "Staff of Wonder");
        }

        [TestMethod]
        [TestCategory("Player Weapons")]
        public void HaveAllExpectedWeapons()
        {
            // Arrange
            PlayerCharacter sut;
            var expectedWeapons = new []
            {
                "Long Bow",
                "Short Bow",
                "Short Sword"
            };

            // Act
            sut = new PlayerCharacter();

            // Assert
            CollectionAssert.AreEqual(sut.Weapons, expectedWeapons);
        }

        [TestMethod]
        [TestCategory("Player Weapons")]
        public void HaveAllExpectedWeapons_AnyOrder()
        {
            // Arrange
            PlayerCharacter sut;
            var expectedWeapons = new[]
            {
                "Short Bow",
                "Short Sword",
                "Long Bow"
            };

            // Act
            sut = new PlayerCharacter();

            // Assert
            CollectionAssert.AreEquivalent(sut.Weapons, expectedWeapons);
        }

        [TestMethod]
        [TestCategory("Player Weapons")]
        public void HaveNoDuplicateWeapons()
        {
            // Arrange
            PlayerCharacter sut;

            // Act
            sut = new PlayerCharacter();

            // Assert
            CollectionAssert.AllItemsAreUnique(sut.Weapons);
        }

        [TestMethod]
        [TestCategory("Player Weapons")]
        public void HaveAtLeastOneKindOfSword()
        {
            // Arrange
            PlayerCharacter sut;

            // Act
            sut = new PlayerCharacter();

            // Assert
            Assert.IsTrue(sut.Weapons.Any(w => w.Contains("Sword")));
        }

        [TestMethod]
        [TestCategory("Player Weapons")]
        public void HaveNoEmptyDefaultWeapons()
        {
            // Arrange
            PlayerCharacter sut;

            // Act
            sut = new PlayerCharacter();

            // Assert
            Assert.IsFalse(sut.Weapons.Any(w => string.IsNullOrWhiteSpace(w)));
        }
    }
}
