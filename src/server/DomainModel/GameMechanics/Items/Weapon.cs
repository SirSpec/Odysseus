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
        public MeleeDamage Damage { get; }
        public Requirements Requirements { get; }
        public IEnumerable<IEnhancement<IStatistic>> Modifiers { get; }

        public Weapon(
            string name,
            Weight weight,
            Requirements requirements,
            MeleeDamage damage,
            IEnumerable<IEnhancement<IStatistic>> modifiers) =>
               (Name, Weight, Requirements, Damage, Modifiers) = (name, weight, requirements, damage, modifiers);
    }
}