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
            var sut = new Slot(SlotType.Chest);

            //Assert
            Assert.True(sut.IsEmpty);
        }

        [Fact]
        public void ItemGetter_EmptySlot_ThrowsInvalidOperationException()
        {
            //Arrange
            var sut = new Slot(SlotType.Chest);

            //Assert
            Assert.Throws<InvalidOperationException>(() => sut.Item);
        }

        [Fact]
        public void ItemSetterGetter_SetItemOfTheSameSlotType_Item()
        {
            //Arrange
            var sut = new Slot(SlotType.Chest);
            var item = new ItemStub(SlotType.Chest);

            //Act
            sut.Item = item;

            //Assert
            Assert.Equal(item, sut.Item);
        }

        [Fact]
        public void ItemSetterGetter_SetItemOfDifferentSlotType_ThrowsInvalidOperationException()
        {
            //Arrange
            var sut = new Slot(SlotType.Chest);
            var item = new ItemStub(SlotType.Gloves);

            //Act
            Action action = () => sut.Item = item;

            //Assert
            Assert.Throws<InvalidOperationException>(action);
        }
    }
}