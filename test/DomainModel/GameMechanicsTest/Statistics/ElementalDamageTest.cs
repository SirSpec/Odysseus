using Odysseus.DomainModel.GameMechanics.Statistics.Base;
using Odysseus.DomainModel.GameMechanics.Statistics.Implementations.Attributes;
using Odysseus.DomainModel.GameMechanics.Statistics.Implementations.Offence;
using System;
using System.Collections.Generic;
using Xunit;

namespace Odysseus.DomainModel.GameMechanicsTest.Statistics
{
    public class ElementalDamageStub : ElementalDamage
    {
    }

    public class ElementalDamageTest
    {
        [Fact]
        public void Value_Default_One()
        {
            //Arrange
            var sut = new ElementalDamageStub();
            var statistics = new List<IPrimaryStatistic> { new Intelligence() };

            //Act
            var results = sut.DeriveValue(statistics);

            //Assert
            Assert.Equal(1, results);
        }

        [Fact]
        public void BaseValueSetter_Negative_ThrowsArgumentException()
        {
            //Arrange
            var sut = new ElementalDamageStub();

            //Act
            Action action = () => sut.BaseValue = -1;

            //Assert
            Assert.Throws<ArgumentException>(action);
        }

        [Fact]
        public void BaseValueSetter_Positive_Six()
        {
            //Arrange
            var sut = new ElementalDamageStub();
            var statistics = new List<IPrimaryStatistic> { new Intelligence() };

            //Act
            sut.BaseValue = 5;
            var results = sut.DeriveValue(statistics);

            //Assert
            Assert.Equal(6, results);
        }
    }
}