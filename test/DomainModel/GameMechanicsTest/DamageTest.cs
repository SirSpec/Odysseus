using Odysseus.DomainModel.GameMechanics;
using System;
using Xunit;

namespace Odysseus.DomainModel.GameMechanicsTest
{
    public class DamageTest
    {
        [Fact]
        public void Constructor_NegativeInput_ThrowsArgumentException()
        {
            //Arrange
            Action sut = () => new Damage(-1, DamageType.Melee);

            //Assert
            Assert.Throws<ArgumentException>(sut);
        }
    }
}
