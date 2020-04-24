using Odysseus.DomainModel.GameMechanics;
using System;
using Xunit;

namespace Odysseus.DomainModel.GameMechanicsTest
{
    public class ResistanceTest
    {
        [Fact]
        public void Constructor_NegativeInput_ThrowsArgumentException()
        {
            //Arrange
            Action sut = () => new Resistance(-1);

            //Assert
            Assert.Throws<ArgumentException>(sut);
        }

        [Fact]
        public void Constructor_InputAboveMaximumLevel_MaximumLevel()
        {
            //Arrange
            const int testValue = 71;
            var sut = new Resistance(testValue);

            //Act
            var uncappedValue = sut.UncappedValue;
            var value = sut.Value;

            //Assert
            Assert.Equal(testValue, uncappedValue);
            Assert.Equal(70, value);
        }
    }
}
