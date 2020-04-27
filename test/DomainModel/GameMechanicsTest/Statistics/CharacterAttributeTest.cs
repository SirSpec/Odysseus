using Odysseus.DomainModel.GameMechanics;
using System;
using Xunit;

namespace Odysseus.DomainModel.GameMechanicsTest.Statistics
{
    public class CharacterAttributeTest
    {
        [Fact]
        public void StrengthConstructor_InputBelowMinimumValue_ThrowsArgumentException()
        {
            //Arrange
            Action sut = () => new Strength(0);

            //Assert
            Assert.Throws<ArgumentException>(sut);
        }

        [Fact]
        public void DexterityConstructor_InputBelowMinimumValue_ThrowsArgumentException()
        {
            //Arrange
            Action sut = () => new Dexterity(0);

            //Assert
            Assert.Throws<ArgumentException>(sut);
        }

        [Fact]
        public void IntelligenceConstructor_InputBelowMinimumValue_ThrowsArgumentException()
        {
            //Arrange
            Action sut = () => new Intelligence(0);

            //Assert
            Assert.Throws<ArgumentException>(sut);
        }

        [Fact]
        public void StrengthIncrease_MethodCalled_IncreaseAttributeValue()
        {
            //Arrange
            var sut = new Strength();

            //Act
            var result = sut.Increase();

            //Assert
            Assert.Equal(2, result.Value);
        }

        [Fact]
        public void DexterityIncrease_MethodCalled_IncreaseAttributeValue()
        {
            //Arrange
            var sut = new Dexterity();

            //Act
            var result = sut.Increase();

            //Assert
            Assert.Equal(2, result.Value);
        }

        [Fact]
        public void IntelligenceIncrease_MethodCalled_IncreaseAttributeValue()
        {
            //Arrange
            var sut = new Intelligence();

            //Act
            var result = sut.Increase();

            //Assert
            Assert.Equal(2, result.Value);
        }
    }
}