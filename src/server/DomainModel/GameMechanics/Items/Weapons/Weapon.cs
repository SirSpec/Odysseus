using Odysseus.DomainModel.GameMechanics.Statistics.Base;
using Odysseus.DomainModel.GameMechanics.Enhancements;
using System.Collections.Generic;
using Odysseus.DomainModel.GameMechanics.Inventory;
using Odysseus.DomainModel.GameMechanics.Items.Base;

namespace Odysseus.DomainModel.GameMechanics.Items.Weapons
{
    public class Weapon : EquipableItem
    {
        public DamageDealt Damage { get; }

        public Weapon(
            SlotType slotType,
            string name,
            Weight weight,
            Requirements requirements,
            DamageDealt damage,
            IEnumerable<IEnhancement<IStatistic>> enhancements)
            : base(slotType, name, weight, requirements, enhancements) =>
               Damage = damage;
    }
}