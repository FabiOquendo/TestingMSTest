using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace GameEngine.Test
{
    [TestClass]
    public class PlayerCharacterShould
    {
        PlayerCharacter sut;

        [TestInitialize]
        public void TestInitialize()
        {
            sut = new PlayerCharacter
            {
                FirstName = "Fabio",
                LastName = "Oquendo"
            };
        }

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
        [PlayerDefaults]
        //[Ignore]
        public void BeInexperiencedWhenNew()
        {
            // Assert
            Assert.IsTrue(sut.IsNoob);
        }

        [TestMethod]
        [PlayerDefaults]
        //[Ignore("Temporarily disable for refactoring")]
        public void NotHaveNickNameByDefault()
        {
            // Assert
            Assert.IsNull(sut.NickName);
        }

        [TestMethod]
        [PlayerDefaults]
        public void StartWithDefaultHealth()
        {
            // Assert
            Assert.AreEqual(100, sut.Health);
        }

        [DataTestMethod]
        [CsvDataSource("Damage.csv")]
        //[DynamicData(nameof(ExternalHealthDamageTestData.TestData), typeof(ExternalHealthDamageTestData))]
        //[DynamicData(nameof(DamageData.GetDamages), typeof(DamageData), DynamicDataSourceType.Method)]
        //[DynamicData(nameof(GetDamages), DynamicDataSourceType.Method)]
        //[DynamicData(nameof(Damages))]
        //[DataRow(0, 100)]
        //[DataRow(1, 99)]
        //[DataRow(50, 50)]
        //[DataRow(100, 1)]
        [PlayerHealth]
        public void TakeDamage(int damage, int expectedHealth)
        {
            // Act
            sut.TakeDamage(damage);

            // Assert
            Assert.AreEqual(expectedHealth, sut.Health);
        }

        [TestMethod]
        [PlayerHealth]
        public void TakeDamage_NotEqual()
        {
            // Act
            sut.TakeDamage(1);

            // Assert
            Assert.AreNotEqual(100, sut.Health);
        }

        [TestMethod]
        [PlayerHealth]
        public void IncreaseHealthAfterSleeping()
        {
            // Act
            sut.Sleep();

            // Assert
            //Assert.IsTrue(sut.Health >= 101 && sut.Health <= 200);
            Assert.That.IsInRange(sut.Health, 101, 200);
        }

        [TestMethod]
        [PlayerName]
        public void CalculateFullName()
        {
            // Assert
            Assert.AreEqual("Fabio Oquendo", sut.FullName);
        }

        [TestMethod]
        [PlayerName]
        public void HaveFullNameStartingWithFirstName()
        {
            // Assert
            StringAssert.StartsWith(sut.FullName, "Fabio");
        }

        [TestMethod]
        [PlayerName]
        public void HaveFullNameEndingWithFirstName()
        {
            // Assert
            StringAssert.EndsWith(sut.FullName, "Oquendo");
        }

        [TestMethod]
        [PlayerName]
        public void CalculateFullName_SubstringAssertExample()
        {
            // Assert
            StringAssert.Contains(sut.FullName, "io Oq");
        }

        [TestMethod]
        [PlayerName]
        public void CalculateFullNameWithTitleCase()
        {
            // Assert
            StringAssert.Matches(sut.FullName, new Regex("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+"));
        }

        [TestMethod]
        [PlayerWeapons]
        public void HaveALongBow()
        {
            // Assert
            CollectionAssert.Contains(sut.Weapons, "Long Bow");
        }

        [TestMethod]
        [PlayerWeapons]
        public void NotHaveAStaffOfWonder()
        {
            // Assert
            CollectionAssert.DoesNotContain(sut.Weapons, "Staff of Wonder");
        }

        [TestMethod]
        [PlayerWeapons]
        public void HaveAllExpectedWeapons()
        {
            // Arrange
            var expectedWeapons = new []
            {
                "Long Bow",
                "Short Bow",
                "Short Sword"
            };

            // Assert
            CollectionAssert.AreEqual(sut.Weapons, expectedWeapons);
        }

        [TestMethod]
        [PlayerWeapons]
        public void HaveAllExpectedWeapons_AnyOrder()
        {
            // Arrange
            var expectedWeapons = new[]
            {
                "Short Bow",
                "Short Sword",
                "Long Bow"
            };

            // Assert
            CollectionAssert.AreEquivalent(sut.Weapons, expectedWeapons);
        }

        [TestMethod]
        [PlayerWeapons]
        public void HaveNoDuplicateWeapons()
        {
            // Assert
            CollectionAssert.AllItemsAreUnique(sut.Weapons);
        }

        [TestMethod]
        [PlayerWeapons]
        public void HaveAtLeastOneKindOfSword()
        {
            // Assert
            //Assert.IsTrue(sut.Weapons.Any(w => w.Contains("Sword")));
            CollectionAssert.That.AtLeastOneItemSatisfy(sut.Weapons, w => w.Contains("Sword"));
        }

        [TestMethod]
        [PlayerWeapons]
        public void HaveNoEmptyDefaultWeapons()
        {
            // Assert
            //Assert.IsFalse(sut.Weapons.Any(w => string.IsNullOrWhiteSpace(w)));
            //CollectionAssert.That.AllItemsNotNullOrWhiteSpace(sut.Weapons);
            //CollectionAssert.That.AllItemsSatisfy(sut.Weapons, w => !string.IsNullOrWhiteSpace(w));
            CollectionAssert.That.All(sut.Weapons, w =>
            {
                StringAssert.That.NotNullOrWhiteSpace(w);
                Assert.IsTrue(w.Length > 5);
            });
        }
    }
}
