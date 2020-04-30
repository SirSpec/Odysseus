using Odysseus.DomainModel.GameMechanics.Statistics.Implementations.Offence;
using Odysseus.DomainModel.GameMechanics.Statistics.Base;
using Odysseus.DomainModel.GameMechanics.Enhancements;
using System.Collections.Generic;
using Odysseus.DomainModel.GameMechanics.Inventory;

namespace Odysseus.DomainModel.GameMechanics.Items
{
    public class Weapon : IEquipable
    {
        public string Name { get; }
        public Weight Weight { get; }
        public Damage Damage { get; }
        public Requirements Requirements { get; }
        public IEnumerable<IEnhancement<IStatistic>> Enhancements { get; }
        public EquipableItemType Type { get; }

        public Weapon(
            string name,
            Weight weight,
            Requirements requirements,
            Damage damage,
            EquipableItemType type,
            IEnumerable<IEnhancement<IStatistic>> enhancements) =>
               (Name, Weight, Requirements, Damage, Type, Enhancements) = (name, weight, requirements, damage, type, enhancements);
    }
}