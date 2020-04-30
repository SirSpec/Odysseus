using Odysseus.DomainModel.GameMechanics.Items;
using System;

namespace Odysseus.DomainModel.GameMechanics.Inventory
{
    public class EquipedEventArgs : EventArgs
    {
        public IEquipable? OldItem { get; }
        public IEquipable? NewItem { get; }
    }
}