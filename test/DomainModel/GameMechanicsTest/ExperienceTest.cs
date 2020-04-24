using Odysseus.DomainModel.GameMechanics;
using System;
using Xunit;

namespace Odysseus.DomainModel.GameMechanicsTest
{
    public class ExperienceTest
    {
        [Fact]
        public void Constructor_NegativeInput_ThrowsArgumentException()
        {
            //Arrange
            Action sut = () => new Experience(-1);

            //Assert
            Assert.Throws<ArgumentException>(sut);
        }

        [Fact]
        public void Constructor_Zero_LevelOne()
        {
            //Arrange
            var sut = new Experience(0);

            //Act
            var result = sut.Level.Value;

            //Assert
            Assert.Equal(1, result);
        }
    }
}
