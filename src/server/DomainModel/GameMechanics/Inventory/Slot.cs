using System;

namespace Odysseus.DomainModel.GameMechanics
{
    public class Slot
    {
        private IItem? item;
        public bool IsEmpty => item is null;
        public IItem Item
        {
            get => item ?? throw new InvalidOperationException();
            set => item = value;
        }
    }
}