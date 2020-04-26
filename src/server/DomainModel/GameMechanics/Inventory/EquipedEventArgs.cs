using System;

namespace Odysseus.DomainModel.GameMechanics
{
    public class EquipedEventArgs : EventArgs
    {
        public IItem? OldItem { get; }
        public IItem? NewItem { get; }
    }
}