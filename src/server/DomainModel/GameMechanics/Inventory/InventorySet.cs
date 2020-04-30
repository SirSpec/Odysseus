using Odysseus.DomainModel.GameMechanics.Items;
using System;

namespace Odysseus.DomainModel.GameMechanics.Inventory
{
    public class InventorySet
    {
        public Equipment Equipment { get; }
        public Backpack Backpack { get; }
        public Gold Gold { get; private set; }
        public double CarryingCapacity { get; private set; }

        public int Weight => Equipment.Weight.Value + Backpack.Weight;

        public InventorySet(Equipment equipment, Backpack backpack, double carryingCapacity) =>
            (Equipment, Backpack, CarryingCapacity) = (equipment, backpack, carryingCapacity);

        public void ChangeCarryingCapacity(double carryingCapacity)
        {
            if (carryingCapacity >= Weight) CarryingCapacity = carryingCapacity;
            else throw new InvalidOperationException($"{nameof(carryingCapacity)}:{carryingCapacity} is smaller than Weight of items:{Weight}.");
        }

        public void Earn(Gold gold) =>
            Gold += gold;

        public void Spend(Gold gold)
        {
            if ((Gold - gold).Value >= 0) Gold -= gold;
            else throw new InvalidOperationException($"Not enough gold: {Gold}.");
        }

        public bool CanPickUp(IItem item) =>
            Weight + item.Weight.Value <= CarryingCapacity && !Backpack.IsFull;

        public void PickUp(IItem item)
        {
            if (CanPickUp(item)) Backpack.Put(item);
            else throw new InvalidOperationException($"Item Weight:{Weight} exceeds Carrying Capacity:{CarryingCapacity}.");
        }

        public void RemoveItem(IItem item)
        {
            if (Backpack.Contains(item)) Backpack.Remove(item);
            else throw new InvalidOperationException($"Item {item} does not exists.");
        }
    }
}