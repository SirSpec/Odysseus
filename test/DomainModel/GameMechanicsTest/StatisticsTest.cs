using Odysseus.DomainModel.GameMechanics;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Odysseus.DomainModel.GameMechanicsTest
{
    public class StatisticsTest
    {
        [Fact]
        public void Constructor_Default_NonEmptyCollection()
        {
            //Arrange
            var sut = new Statistics();

            //Act
            var result = sut.All;

            //Assert
            Assert.NotEmpty(result);
        }

        [Fact]
        public void GetStatistic_Default_NonEmptyCollection()
        {
            //Arrange
            var sut = new Statistics();

            //Act
            var result = sut.GetStatistic<Health>();

            //Assert
            Assert.IsType<Health>(result);
        }

        [Fact]
        public void Change_Default_NewStatistic()
        {
            //Arrange
            var sut = new Statistics();
            var newStatistic = new Health(20);
            var expectedCount = sut.All.Count(); 

            //Act
            sut.Change(newStatistic);
            var result = sut.GetStatistic<Health>();

            //Assert
            Assert.Equal(expectedCount, sut.All.Count());
            Assert.Equal(20, result.Value);
        }

        [Fact]
        public void Apply_HealthModifier_NewHealthValue()
        {
            //Arrange
            var statistics = new Statistics();
            var sut = new HealthModifier(10);
            statistics.Apply(sut);


            //Act
            var result = statistics.GetStatistic<Health>();

            //Assert
            Assert.Equal(23, result.Value);
        }
    }
}
