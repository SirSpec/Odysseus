using Odysseus.DomainModel.GameMechanics;
using System;
using Xunit;

namespace Odysseus.DomainModel.GameMechanicsTest
{
    public class CharacterAttributeTest
    {
        [Fact]
        public void Constructor_InputBelowMinimumValue_ThrowsArgumentException()
        {
            //Arrange
            Action sut = () => new Strength(0);

            //Assert
            Assert.Throws<ArgumentException>(sut);
        }

        [Fact]
        public void Equals_TheSameValues_True()
        {
            //Arrange
            var sut1 = new Strength(1);
            var sut2 = new Strength(1);

            //Act
            var result1 = sut1.Equals(sut2);
            var result2 = sut2.Equals(sut1);
            var result3 = sut1.Equals(sut1);

            //Assert
            Assert.True(result1);
            Assert.True(result2);
            Assert.True(result3);
        }

        [Fact]
        public void Equals_DifferentValues_False()
        {
            //Arrange
            var sut1 = new Strength(1);
            var sut2 = new Strength(2);

            //Act
            var result1 = sut1.Equals(sut2);
            var result2 = sut2.Equals(sut1);

            //Assert
            Assert.False(result1);
            Assert.False(result2);
        }
    }
}
