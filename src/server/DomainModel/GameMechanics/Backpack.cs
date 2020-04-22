using System;
using System.Collections.Generic;
using System.Linq;

namespace Odysseus.DomainModel.GameMechanics
{
    public class Backpack
    {
        private readonly List<Item> items;

        public int Capacity { get; }
        public IEnumerable<Item> Items => items;
        public bool IsFull => Items.Count() == Capacity;
        public double Weight => Items.Sum(item => item.Weight);

        public Backpack(int capacity) =>
            (items, Capacity) = (new List<Item>(), capacity);

        public bool Contains(Item item) =>
            Items.Contains(item);

        public void Put(Item item)
        {
            if (!IsFull) items.Add(item);
            else throw new InvalidOperationException($"{nameof(Backpack)} of {nameof(Capacity)}:{Capacity} is already full.");
        }

        public void Remove(Item item)
        {
            if (items.Contains(item)) items.Remove(item);
            else throw new InvalidOperationException($"Item {item} does not exists.");
        }
    }
}