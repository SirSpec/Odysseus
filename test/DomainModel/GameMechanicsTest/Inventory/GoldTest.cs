using Odysseus.DomainModel.GameMechanics.Inventory;
using System;
using Xunit;

namespace Odysseus.DomainModel.GameMechanicsTest.Inventory
{
    public class GoldTest
    {
        [Fact]
        public void Constructor_NegativeInput_ThrowsArgumentException()
        {
            //Arrange
            Action sut = () => new Gold(-1);

            //Assert
            Assert.Throws<ArgumentException>(sut);
        }
    }
}