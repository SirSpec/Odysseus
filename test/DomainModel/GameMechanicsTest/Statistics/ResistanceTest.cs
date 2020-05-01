using Odysseus.DomainModel.GameMechanics.Enhancements;
using Odysseus.DomainModel.GameMechanics.Statistics.Implementations.Defence;
using Xunit;

namespace Odysseus.DomainModel.GameMechanicsTest.Statistics
{
    public class ResistanceTest
    {
        public class ResistanceStub : Resistance
        { }

        [Fact]
        public void Value_Default_One()
        {
            //Arrange
            var sut = new ResistanceStub();

            //Act
            var results = sut.Value;

            //Assert
            Assert.Equal(Resistance.Minimum, results);
        }

        [Fact]
        public void Value_Enhanced_EnhancedBaseValue()
        {
            //Arrange
            var sut = new ResistanceStub();
            
            //Act
            sut.AddEnhancement(new FlatEnhancement<ResistanceStub>(9));
            sut.AddEnhancement(new PercentageEnhancement<ResistanceStub>(100));
            var results = sut.Value;

            //Assert
            Assert.Equal(9, results);
        }

        [Fact]
        public void Value_EnhancedMoreThanMaximum_Maximum()
        {
            //Arrange
            var sut = new ResistanceStub();

            //Act
            sut.AddEnhancement(new FlatEnhancement<ResistanceStub>(Resistance.Maximum + 1));
            var results = sut.Value;

            //Assert
            Assert.Equal(Resistance.Maximum, results);
        }

        [Fact]
        public void Value_EnhancedBelowMinimum_Minumum()
        {
            //Arrange
            var sut = new ResistanceStub();

            //Act
            sut.AddEnhancement(new FlatEnhancement<ResistanceStub>(-1));
            var results = sut.Value;

            //Assert
            Assert.Equal(Resistance.Minimum, results);
        }
    }
}