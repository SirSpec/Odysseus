using Odysseus.DomainModel.GameMechanics.Enhancements;
using Odysseus.DomainModel.GameMechanics.Statistics.Base;
using Odysseus.DomainModel.GameMechanics.Statistics.Implementations.Attributes;
using Odysseus.DomainModel.GameMechanics.Statistics.Implementations.Defence;
using Odysseus.DomainModel.GameMechanics.Statistics.Implementations.Offence;
using System.Collections.Generic;
using Xunit;

namespace Odysseus.DomainModel.GameMechanicsTest.Statistics
{
    public class MeleeDamageTest
    {
        [Fact]
        public void Value_Default_One()
        {
            //Arrange
            var sut = new MeleeDamage();

            //Act
            var results = sut.DeriveValue(new List<IPrimaryStatistic> { new Strength() });

            //Assert
            Assert.Equal(1, results);
        }

        //[Fact]
        //public void Value_Enhanced_EnhancedBaseValue()
        //{
        //    //Arrange
        //    var sut = new MeleeDamage();
            
        //    //Act
        //    sut.AddEnhancement(new FlatEnhancement<MeleeDamage>(9));
        //    sut.AddEnhancement(new PercentageEnhancement<MeleeDamage>(100));
        //    var results = sut.Value;

        //    //Assert
        //    Assert.Equal(9, results);
        //}

        //[Fact]
        //public void Value_EnhancedMoreThanMaximum_Maximum()
        //{
        //    //Arrange
        //    var sut = new MeleeDamage();

        //    //Act
        //    sut.AddEnhancement(new FlatEnhancement<MeleeDamage>(Resistance.Maximum + 1));
        //    var results = sut.Value;

        //    //Assert
        //    Assert.Equal(Resistance.Maximum, results);
        //}

        //[Fact]
        //public void Value_EnhancedBelowMinimum_Minumum()
        //{
        //    //Arrange
        //    var sut = new MeleeDamage();

        //    //Act
        //    sut.AddEnhancement(new FlatEnhancement<MeleeDamage>(-1));
        //    var results = sut.Value;

        //    //Assert
        //    Assert.Equal(Resistance.Minimum, results);
        //}
    }
}