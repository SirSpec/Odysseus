using Odysseus.DomainModel.GameMechanics.Inventory;
using Odysseus.DomainModel.GameMechanics.Statistics.Base;
using Odysseus.DomainModel.GameMechanics.Enhancements;
using Odysseus.DomainModel.GameMechanics.Statistics.Implementations.Defence;
using System.Collections.Generic;

namespace Odysseus.DomainModel.GameMechanics.Items
{
    public class BodyArmor : IEquipable
    {
        public string Name { get; }
        public Weight Weight { get; }
        public Armor Armor { get; }
        public Requirements Requirements { get; }
        public IEnumerable<IEnhancement<IStatistic>> Modifiers { get; }

        public BodyArmor(
            string name,
            Weight weight,
            Requirements requirements,
            Armor armor,
            IEnumerable<IEnhancement<IStatistic>> modifiers) =>
                (Name, Weight, Requirements, Armor, Modifiers) = (name, weight, requirements, armor, modifiers);
    }
}