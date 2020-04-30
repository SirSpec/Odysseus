using Odysseus.DomainModel.GameMechanics.Inventory;
using System;
using Xunit;

namespace Odysseus.DomainModel.GameMechanicsTest.Inventory
{
    public class SlotTest
    {
        [Fact]
        public void Constructor_IsEmpty_True()
        {
            //Arrange
            var sut = new Slot();

            //Assert
            Assert.True(sut.IsEmpty);
        }

        [Fact]
        public void ItemGetter_EmptySlot_ThrowsInvalidOperationException()
        {
            //Arrange
            var sut = new Slot();

            //Assert
            Assert.Throws<InvalidOperationException>(() => sut.Item);
        }

        [Fact]
        public void ItemSetterGetter_SetItem_Item()
        {
            //Arrange
            var sut = new Slot();
            var item = new ItemStub();

            //Act
            sut.Item = item;

            //Assert
            Assert.Equal(item, sut.Item);
        }
    }
}