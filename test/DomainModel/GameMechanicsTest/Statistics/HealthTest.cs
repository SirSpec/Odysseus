using Odysseus.DomainModel.GameMechanics.Statistics.Base;
using Odysseus.DomainModel.GameMechanics.Statistics.Implementations.Attributes;
using Odysseus.DomainModel.GameMechanics.Statistics.Implementations.Main;
using System.Collections.Generic;
using Xunit;

namespace Odysseus.DomainModel.GameMechanicsTest.Statistics
{
    public class HealthTest
    {
        [Fact]
        public void DeriveValue_Default_13()
        {
            //Arrange
            var sut = new Health();
            var statistics = new List<IPrimaryStatistic> { new Strength() };

            //Act
            var results = sut.DeriveValue(statistics);

            //Assert
            Assert.Equal(13, results);
        }

        [Fact]
        public void LevelUp_DeriveValue_25()
        {
            //Arrange
            var sut = new Health();
            var statistics = new List<IPrimaryStatistic> { new Strength() };

            //Act
            sut.LevelUp();
            var results = sut.DeriveValue(statistics);

            //Assert
            Assert.Equal(25, results);
        }

        [Fact]
        public void DeriveValue_TwoPointsOfStrength_14()
        {
            //Arrange
            var sut = new Health();
            var strength = new Strength();
            strength.LevelUp();
            var statistics = new List<IPrimaryStatistic> { strength };

            //Act
            var results = sut.DeriveValue(statistics);

            //Assert
            Assert.Equal(14, results);
        }
    }
}