using Odysseus.DomainModel.GameMechanics.Inventory;
using Odysseus.DomainModel.GameMechanics.Statistics.Base;
using Odysseus.DomainModel.GameMechanics.Enhancements;
using System.Collections.Generic;

namespace Odysseus.DomainModel.GameMechanics.Items.Base
{
    public class EquipableItem : IEquipable
    {
        public string Name { get; }
        public Weight Weight { get; }
        public Requirements Requirements { get; }
        public IEnumerable<IEnhancement<IStatistic>> Enhancements { get; }
        public SlotType SlotType { get; }

        public EquipableItem(
            SlotType slotType,
            string name,
            Weight weight,
            Requirements requirements,
            IEnumerable<IEnhancement<IStatistic>> modifiers) =>
                (SlotType, Name, Weight, Requirements, Enhancements) = (slotType, name, weight, requirements, modifiers);
    }
}