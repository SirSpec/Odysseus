using Odysseus.DomainModel.GameMechanics.Enhancements;
using Odysseus.DomainModel.GameMechanics.Inventory;
using Odysseus.DomainModel.GameMechanics.Items;
using Odysseus.DomainModel.GameMechanics.Items.Base;
using Odysseus.DomainModel.GameMechanics.Statistics.Base;
using Odysseus.Framework.Randomizer;
using System.Collections.Generic;

namespace Odysseus.DomainModel.GameMechanicsTest.Inventory
{
    public class ItemStub : IEquipable
    {
        public string Name => "Test";

        public Weight Weight { get; } = new Weight(Randomizer.RandomInteger(1, 5));

        public Requirements Requirements => new Requirements();

        public SlotType SlotType { get; }

        public IEnumerable<IEnhancement<IStatistic>> Enhancements => new List<IEnhancement<IStatistic>>();

        public ItemStub()
        {
            SlotType = SlotType.Chest;
        }

        public ItemStub(Weight weight)
        {
            Weight = weight;
        }

        public ItemStub(SlotType slotType)
        {
            SlotType = slotType;
        }
    }
}