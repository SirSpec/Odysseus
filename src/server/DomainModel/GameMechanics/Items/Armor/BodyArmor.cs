using Odysseus.DomainModel.GameMechanics.Statistics.Base;
using Odysseus.DomainModel.GameMechanics.Enhancements;
using System.Collections.Generic;
using Odysseus.DomainModel.GameMechanics.Inventory;
using Odysseus.DomainModel.GameMechanics.Items.Base;

namespace Odysseus.DomainModel.GameMechanics.Items.Armor
{
    public class BodyArmor : EquipableItem
    {
        public ArmorValue Armor { get; }

        public BodyArmor(
            SlotType slotType,
            string name,
            Weight weight,
            Requirements requirements,
            ArmorValue armor,
            IEnumerable<IEnhancement<IStatistic>> enhancements)
            : base(slotType, name, weight, requirements, enhancements) =>
               Armor = armor;
    }
}