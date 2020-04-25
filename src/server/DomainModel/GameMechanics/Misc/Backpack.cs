using System;
using System.Collections.Generic;
using System.Linq;

namespace Odysseus.DomainModel.GameMechanics
{
    public class Backpack
    {
        private readonly IList<IItem> items;

        public int Capacity { get; }
        public IEnumerable<IItem> Items => items;
        public bool IsFull => Items.Count() == Capacity;
        public double Weight => Items.Sum(item => item.Weight);

        public Backpack(int capacity) =>
            (items, Capacity) = (new List<IItem>(), capacity);

        public bool Contains(IItem item) =>
            Items.Contains(item);

        public void Put(IItem item)
        {
            if (!IsFull) items.Add(item);
            else throw new InvalidOperationException($"{nameof(Backpack)} of {nameof(Capacity)}:{Capacity} is already full.");
        }

        public void Remove(IItem item)
        {
            if (items.Contains(item)) items.Remove(item);
            else throw new InvalidOperationException($"Item {item} does not exists.");
        }
    }
}