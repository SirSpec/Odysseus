using Odysseus.DomainModel.GameMechanics;
using Xunit;

namespace Odysseus.DomainModel.GameMechanicsTest
{
    public class PlayerCharacterTest
    {
        [Fact]
        public void Default()
        {
            //Arrange
            var sut = new PlayerCharacter("TestSut");

            //Act

            //Assert
            Assert.True(true);
        }
    }
}