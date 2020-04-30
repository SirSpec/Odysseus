using Odysseus.DomainModel.GameMechanics.Statistics.Base;
using Odysseus.DomainModel.GameMechanics.Enhancements;
using Xunit;

namespace Odysseus.DomainModel.GameMechanics.StatisticsTest.Enhancements
{
    public class EnhancementTest
    {
        [Fact]
        public void FlatEnhance_One_One()
        {
            //Arrange
            var flatValue = 5;
            var sut = new FlatEnhancement<IStatistic>(flatValue);

            //Act
            var results = sut.Enhance(2);

            //Assert
            Assert.Equal(flatValue, results);
        }

        [Fact]
        public void PercentageEnhancement_50_50PercentOfValue()
        {
            //Arrange
            var sut = new PercentageEnhancement<IStatistic>(50);

            //Act
            var results = sut.Enhance(10);

            //Assert
            Assert.Equal(5, results);
        }
    }
}