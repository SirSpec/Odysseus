using Odysseus.DomainModel.GameMechanics.Statistics.Base;
using Odysseus.DomainModel.GameMechanics.Statistics.Implementations.Attributes;
using Odysseus.DomainModel.GameMechanics.Statistics.Implementations.Main;
using System.Collections.Generic;
using Xunit;

namespace Odysseus.DomainModel.GameMechanicsTest.Statistics
{
    public class ManaTest
    {
        [Fact]
        public void DeriveValue_Default_6()
        {
            //Arrange
            var sut = new Mana();
            var statistics = new List<IPrimaryStatistic> { new Intelligence() };

            //Act
            var results = sut.DeriveValue(statistics);

            //Assert
            Assert.Equal(7, results);
        }

        [Fact]
        public void LevelUp_DeriveValue_8()
        {
            //Arrange
            var sut = new Mana();
            var statistics = new List<IPrimaryStatistic> { new Intelligence() };

            //Act
            sut.LevelUp();
            var results = sut.DeriveValue(statistics);

            //Assert
            Assert.Equal(13, results);
        }

        [Fact]
        public void DeriveValue_TwoPointsOfIntelligence_8()
        {
            //Arrange
            var sut = new Mana();
            var inteligence = new Intelligence();
            inteligence.LevelUp();
            var statistics = new List<IPrimaryStatistic> { inteligence };

            //Act
            var results = sut.DeriveValue(statistics);

            //Assert
            Assert.Equal(8, results);
        }
    }
}