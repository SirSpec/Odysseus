using Odysseus.DomainModel.GameMechanics.Statistics.Base;
using Odysseus.DomainModel.GameMechanics.Enhancements;
using System.Collections.Generic;
using Odysseus.DomainModel.GameMechanics.Inventory;

namespace Odysseus.DomainModel.GameMechanics.Items.Base
{
    public interface IEquipable : IItem
    {
        public SlotType SlotType { get; }
        public Requirements Requirements { get; }
        public IEnumerable<IEnhancement<IStatistic>> Enhancements { get; }
    }
}