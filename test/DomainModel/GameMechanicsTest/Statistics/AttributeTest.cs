using Odysseus.DomainModel.GameMechanics.Enhancements;
using Odysseus.DomainModel.GameMechanics.Statistics.Implementations.Attributes;
using Xunit;

namespace Odysseus.DomainModel.GameMechanicsTest.Statistics
{
    public class AttributeTest
    {
        public class AttributeStub : CharacterAttribute
        { }

        [Fact]
        public void Value_Default_One()
        {
            //Arrange
            var sut = new AttributeStub();

            //Act
            var results = sut.Value;

            //Assert
            Assert.Equal(1, results);
        }

        [Fact]
        public void LevelUp_Once_ValueEqualsTwo()
        {
            //Arrange
            var sut = new AttributeStub();

            //Act
            sut.LevelUp();
            var results = sut.Value;

            //Assert
            Assert.Equal(2, results);
        }

        [Fact]
        public void Value_Enhanced_EnhancedBaseValue()
        {
            //Arrange
            var sut = new AttributeStub();
            
            //Act
            sut.AddEnhancement(new FlatEnhancement<AttributeStub>(9));
            sut.AddEnhancement(new PercentageEnhancement<AttributeStub>(100));
            var results = sut.Value;

            //Assert
            Assert.Equal(11, results);
        }
    }
}