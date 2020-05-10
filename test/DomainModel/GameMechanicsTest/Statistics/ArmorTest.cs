using Odysseus.DomainModel.GameMechanics.Statistics.Implementations.Defence;
using System;
using Xunit;

namespace Odysseus.DomainModel.GameMechanicsTest.Statistics
{
    public class ArmorTest
    {
        [Fact]
        public void BaseValueSetter_Negative_ThrowsArgumentException()
        {
            //Arrange
            var sut = new Armor();

            //Act
            Action action = () => sut.BaseValue = -1;

            //Assert
            Assert.Throws<ArgumentException>(action);
        }

        [Fact]
        public void Value_Default_Zero()
        {
            //Arrange
            var sut = new Armor();

            //Act
            var results = sut.Value;

            //Assert
            Assert.Equal(0, results);
        }

        [Fact]
        public void BaseValueSetter_Positive_Zero()
        {
            //Arrange
            const int testValue = 5;
            var sut = new Armor();

            //Act
            sut.BaseValue = testValue;

            //Assert
            Assert.Equal(testValue, sut.Value);
        }
    }
}