using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Text.RegularExpressions;

namespace GameEngine.Test
{
    [TestClass]
    public class PlayerCharacterShould
    {
        [TestMethod]
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
        public void StartWithDefaultHealth()
        {
            // Arrange
            PlayerCharacter sut;

            // Act
            sut = new PlayerCharacter();

            // Assert
            Assert.AreEqual(100, sut.Health);
        }

        [TestMethod]
        public void TakeDamage()
        {
            // Arrange
            PlayerCharacter sut = new PlayerCharacter();

            // Act
            sut.TakeDamage(1);

            // Assert
            Assert.AreEqual(99, sut.Health);
        }

        [TestMethod]
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