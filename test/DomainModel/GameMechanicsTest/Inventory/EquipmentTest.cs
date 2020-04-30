using Odysseus.DomainModel.GameMechanics.Inventory;
using System;
using Xunit;

namespace Odysseus.DomainModel.GameMechanicsTest.Inventory
{
    public class EquipmentTest
    {
        [Fact]
        public void Weight_Empty_Zero()
        {
            //Arrange
            var sut = new Equipment();

            //Assert
            Assert.Equal(Weight.Zero, sut.Weight);
        }
    }
}