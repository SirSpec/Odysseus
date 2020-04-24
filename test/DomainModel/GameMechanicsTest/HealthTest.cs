using Odysseus.DomainModel.GameMechanics;
using Xunit;

namespace Odysseus.DomainModel.GameMechanicsTest
{
    public class HealthTest
    {
        [Fact]
        public void Constructor_NewCharacter_13()
        {
            //Arrange
            var sut = new Health(new Level(1), new CharacterAttribute(1));

            //Act
            var result = sut.Value;

            //Assert
            Assert.Equal(13, result);
        }

        [Fact]
        public void Constructor_MaxLevelCharacterWithNoStrenght_1201()
        {
            //Arrange
            var sut = new Health(new Level(100), new CharacterAttribute(1));

            //Act
            var result = sut.Value;

            //Assert
            Assert.Equal(1201, result);
        }

        [Fact]
        public void Constructor_MaxLevelCharacterWith100Strenght_1300()
        {
            //Arrange
            var sut = new Health(new Level(100), new CharacterAttribute(100));

            //Act
            var result = sut.Value;

            //Assert
            Assert.Equal(1300, result);
        }
    }
}
