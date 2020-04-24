using Odysseus.DomainModel.GameMechanics;
using System;
using Xunit;

namespace Odysseus.DomainModel.GameMechanicsTest
{
    public class ArmorTest
    {
        [Fact]
        public void Constructor_NegativeInput_ThrowsArgumentException()
        {
            //Arrange
            Action sut = () => new Armor(-1);

            //Assert
            Assert.Throws<ArgumentException>(sut);
        }
    }
}
