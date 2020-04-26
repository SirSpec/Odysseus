using Odysseus.DomainModel.GameMechanics;
using Xunit;

namespace Odysseus.DomainModel.GameMechanicsTest
{
    public class ManaTest
    {
        [Fact]
        public void Constructor_Default_7()
        {
            //Arrange
            var sut = new Mana();

            //Act
            var result = sut.Value;

            //Assert
            Assert.Equal(7, result);
        }

        [Fact]
        public void Constructor_NewCharacter_7()
        {
            //Arrange
            var sut = new Mana(new Level(1), new Intelligence(1));

            //Act
            var result = sut.Value;

            //Assert
            Assert.Equal(7, result);
        }

        [Fact]
        public void Constructor_MaxLevelCharacterWithNoIntelligence_601()
        {
            //Arrange
            var sut = new Mana(new Level(100), new Intelligence(1));

            //Act
            var result = sut.Value;

            //Assert
            Assert.Equal(601, result);
        }

        [Fact]
        public void Constructor_MaxLevelCharacterWith100Intelligence_700()
        {
            //Arrange
            var sut = new Mana(new Level(100), new Intelligence(100));

            //Act
            var result = sut.Value;

            //Assert
            Assert.Equal(700, result);
        }
    }
}
