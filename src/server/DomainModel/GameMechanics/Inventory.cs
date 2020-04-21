using System;
using System.Collections.Generic;
using System.Linq;

namespace Odysseus.DomainModel.GameMechanics
{
    public class Inventory
    {
        private readonly List<Item> items;

        public IEnumerable<Item> Items => items;
        public double Weight => Items.Sum(item => item.Weight);
        public double CarryingCapacity { get; private set; }
        public int Gold { get; private set; }

        public Inventory(double carryingCapacity) =>
            (items, CarryingCapacity) = (new List<Item>(), carryingCapacity);

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

        public void PickUp(Item item)
        {
            if (Weight + item.Weight <= CarryingCapacity) items.Add(item);
            else throw new InvalidOperationException($"Item Weight:{Weight} exceeds Carrying Capacity:{CarryingCapacity}.");
        }

        public void RemoveItem(Item item)
        {
            if (items.Contains(item)) items.Remove(item);
            else throw new InvalidOperationException($"Item {item} does not exists.");
        }
    }
}