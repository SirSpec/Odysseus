using System;
using System.Linq;

namespace Odysseus.DomainModel.GameMechanics
{

    public class Inventory
    {
        public Equipment Equipment { get; }
        public Backpack Backpack { get; }
        public int Gold { get; private set; }
        public double CarryingCapacity { get; private set; }

        public double Weight => Equipment.Weight + Backpack.Weight;

        public Inventory(Equipment equipment, Backpack backpack, double carryingCapacity) =>
            (Equipment, Backpack, CarryingCapacity) = (equipment, backpack, carryingCapacity);

        public void ChangeCarryingCapacity(double carryingCapacity)
        {
            if (carryingCapacity >= Weight) CarryingCapacity = carryingCapacity;
            else throw new InvalidOperationException($"{nameof(carryingCapacity)}:{carryingCapacity} is smaller than Weight of items:{Weight}.");
        }

        public void Earn(int gold) =>
            Gold += gold;

        public void Spend(int gold)
        {
            if (Gold - gold >= 0) Gold -= gold;
            else throw new InvalidOperationException($"Not enough gold: {Gold}.");
        }

        public bool CanPickUp(Item item) =>
            Weight + item.Weight <= CarryingCapacity && !Backpack.IsFull;

        public void PickUp(Item item)
        {
            if (CanPickUp(item)) Backpack.Put(item);
            else throw new InvalidOperationException($"Item Weight:{Weight} exceeds Carrying Capacity:{CarryingCapacity}.");
        }

        public void RemoveItem(Item item)
        {
            if (Backpack.Contains(item)) Backpack.Remove(item);
            else throw new InvalidOperationException($"Item {item} does not exists.");
        }
    }
}