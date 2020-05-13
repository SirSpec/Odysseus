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

        [Fact]
        public void Equip_ValidItem_ItemSet()
        {
            //Arrange
            var sut = new Equipment();
            var testItem = new ItemStub();

            //Act
            sut.Equip(testItem);

            //Assert
            Assert.Equal(testItem.Weight, sut.Weight);
            Assert.Contains(testItem, sut.EquipedItems);
        }

        [Fact]
        public void Equip_TheSameItemType_ReplaceItem()
        {
            //Arrange
            var sut = new Equipment();
            var testItem1 = new ItemStub(SlotType.Boots);
            var testItem2 = new ItemStub(SlotType.Boots);

            //Act
            sut.Equip(testItem1);
            sut.Equip(testItem2);

            //Assert
            Assert.Equal(testItem2.Weight, sut.Weight);
            Assert.Contains(testItem2, sut.EquipedItems);
            Assert.DoesNotContain(testItem1, sut.EquipedItems);
        }

        [Fact]
        public void EquipedEvent_ValidItem_NewItemEventTriggered()
        {
            //Arrange
            var sut = new Equipment();
            var testItem = new ItemStub(SlotType.Boots);

            //Act
            Action action = () => sut.Equip(testItem);

            //Assert
            Assert.Raises<EquipedEventArgs>(handler => sut.Equiped += handler, handler => sut.Equiped -= handler, action);
        }

        [Fact]
        public void EquipedEvent_TheSameItemType_ReplaceItemEventTriggered()
        {
            //Arrange
            var sut = new Equipment();
            var testItem1 = new ItemStub(SlotType.Boots);
            var testItem2 = new ItemStub(SlotType.Boots);

            //Act
            sut.Equip(testItem1);
            Action action = () => sut.Equip(testItem2);

            //Assert
            Assert.Raises<EquipedEventArgs>(handler => sut.Equiped += handler, handler => sut.Equiped -= handler, action);
        }

        [Fact]
        public void Weight_MultipleItems_SumOfitemsWeight()
        {
            //Arrange
            var sut = new Equipment();
            var testItem1 = new ItemStub(SlotType.Chest);
            var testItem2 = new ItemStub(SlotType.Boots);

            //Act
            sut.Equip(testItem1);
            sut.Equip(testItem2);

            //Assert
            Assert.Equal(testItem1.Weight + testItem2.Weight, sut.Weight);
        }
    }
}