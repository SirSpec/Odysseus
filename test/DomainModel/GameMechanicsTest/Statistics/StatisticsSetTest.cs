using System;
using Odysseus.DomainModel.GameMechanics.Statistics;
using Odysseus.DomainModel.GameMechanics.Statistics.Base;
using Odysseus.DomainModel.GameMechanics.Enhancements;
using Odysseus.DomainModel.GameMechanics.Statistics.Implementations.Attributes;
using Odysseus.DomainModel.GameMechanics.Statistics.Implementations.Main;
using Xunit;

namespace Odysseus.DomainModel.GameMechanics.StatisticsTest
{
    public class StatisticsSetTest
    {
        [Fact]
        public void GetStatistics_IStatistic_AllStatistics()
        {
            //Arrange
            var sut = new StatisticsSet();

            //Act
            var results = sut.GetStatistics<IStatistic>();

            //Assert
            Assert.NotEmpty(results);
        }

        [Fact]
        public void GetStatistics_IPrimaryStatistic_AllPrimaryStatistics()
        {
            //Arrange
            var sut = new StatisticsSet();

            //Act
            var results = sut.GetStatistics<IPrimaryStatistic>();

            //Assert
            Assert.NotEmpty(results);
        }

        [Fact]
        public void GetStatistics_IPrimaryStatistic_AllDerivedStatistics()
        {
            //Arrange
            var sut = new StatisticsSet();

            //Act
            var results = sut.GetStatistics<IDerivedStatistic>();

            //Assert
            Assert.NotEmpty(results);
        }

        [Fact]
        public void GetPrimaryStatistic_IPrimaryStatistic_ThrowsInvalidOperationException()
        {
            //Arrange
            var sut = new StatisticsSet();
            
            //Act
            Func<object> results = () => sut.GetPrimaryStatistic<IPrimaryStatistic>();

            //Assert
            Assert.Throws<InvalidOperationException>(results);
        }

        [Fact]
        public void GetPrimaryStatistic_Strength_StrengthValue()
        {
            //Arrange
            var sut = new StatisticsSet();

            //Act
            var results = sut.GetPrimaryStatistic<Strength>();

            //Assert
            Assert.Equal(1, results);
        }

        [Fact]
        public void GetDerivedStatistic_IDerivedStatistic_ThrowsInvalidOperationException()
        {
            //Arrange
            var sut = new StatisticsSet();

            //Act
            Func<object> results = () => sut.GetDerivedStatistic<IDerivedStatistic>();

            //Assert
            Assert.Throws<InvalidOperationException>(results);
        }

        [Fact]
        public void GetDerivedStatistic_Health_HealthValue()
        {
            //Arrange
            var sut = new StatisticsSet();

            //Act
            var results = sut.GetDerivedStatistic<Health>();

            //Assert
            Assert.Equal(13, results);
        }

        [Fact]
        public void Apply_FlatHealthModifier_NewHealthValue()
        {
            //Arrange
            var statistics = new StatisticsSet();
            var sut = new FlatEnhancement<Health>(10);
            statistics.Apply(sut);

            //Act
            var result = statistics.GetDerivedStatistic<Health>();

            //Assert
            Assert.Equal(23, result);
        }

        [Fact]
        public void Apply_MultipleHealthModifier_NewHealthValue()
        {
            //Arrange
            var statistics = new StatisticsSet();
            var sut = new IEnhancement<IStatistic>[] { new FlatEnhancement<Health>(10), new PercentageEnhancement<Health>(20) };
            statistics.Apply(sut);

            //Act
            var result = statistics.GetDerivedStatistic<Health>();

            //Assert
            Assert.Equal(25, result);
        }

        [Fact]
        public void Remove_FlatHealthModifier_DefaultValue()
        {
            //Arrange
            var statistics = new StatisticsSet();
            var sut = new FlatEnhancement<Health>(10);
            statistics.Apply(sut);

            //Act
            statistics.Remove(sut);
            var result = statistics.GetDerivedStatistic<Health>();

            //Assert
            Assert.Equal(13, result);
        }

        [Fact]
        public void Remove_MultipleHealthModifier_DefaultValue()
        {
            //Arrange
            var statistics = new StatisticsSet();
            var sut = new IEnhancement<IStatistic>[] { new FlatEnhancement<Health>(10), new PercentageEnhancement<Health>(20) };
            statistics.Apply(sut);

            //Act
            statistics.Remove(sut);
            var result = statistics.GetDerivedStatistic<Health>();

            //Assert
            Assert.Equal(13, result);
        }
    }
}
