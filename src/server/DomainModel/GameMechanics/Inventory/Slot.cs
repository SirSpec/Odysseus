using Odysseus.DomainModel.GameMechanics.Items;
using System;

namespace Odysseus.DomainModel.GameMechanics.Inventory
{
    public class Slot
    {
        private IEquipable? item;
        public bool IsEmpty => item is null;
        public IEquipable Item
        {
            get => item ?? throw new InvalidOperationException();
            set => item = value;
        }
    }
}