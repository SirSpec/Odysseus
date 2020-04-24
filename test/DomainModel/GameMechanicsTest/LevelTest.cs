using Odysseus.DomainModel.GameMechanics;
using System;
using Xunit;

namespace Odysseus.DomainModel.GameMechanicsTest
{
    public class LevelTest
    {
        [Fact]
        public void Constructor_InputBelowMinimumLevel_ThrowsArgumentException()
        {
            //Arrange
            Action sut = () => new Level(0);

            //Assert
            Assert.Throws<ArgumentException>(sut);
        }

        [Fact]
        public void Constructor_InputAboveMaximumLevel_ThrowsArgumentException()
        {
            //Arrange
            Action sut = () => new Level(101);

            //Assert
            Assert.Throws<ArgumentException>(sut);
        }

        [Fact]
        public void Constructor_InputEdgeCase_ValidObjects()
        {
            //Arrange
            var sut1 = new Level(1);
            var sut2 = new Level(100);

            //Act
            var result1 = sut1.Value;
            var result2 = sut2.Value;

            //Assert
            Assert.Equal(1, result1);
            Assert.Equal(100, result2);
        }

        [Fact]
        public void Equals_TheSameLevels_True()
        {
            //Arrange
            var sut1 = new Level(1);
            var sut2 = new Level(1);

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
        public void Equals_DifferentLevels_False()
        {
            //Arrange
            var sut1 = new Level(1);
            var sut2 = new Level(2);

            //Act
            var result1 = sut1.Equals(sut2);
            var result2 = sut2.Equals(sut1);

            //Assert
            Assert.False(result1);
            Assert.False(result2);
        }
    }
}