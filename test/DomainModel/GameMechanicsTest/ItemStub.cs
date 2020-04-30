using Odysseus.DomainModel.GameMechanics.Enhancements;
using Odysseus.DomainModel.GameMechanics.Inventory;
using Odysseus.DomainModel.GameMechanics.Items;
using Odysseus.DomainModel.GameMechanics.Statistics.Base;
using Odysseus.Framework.Randomizer;
using System;
using System.Collections.Generic;

namespace Odysseus.DomainModel.GameMechanicsTest.Inventory
{
    public class ItemStub : IEquipable
    {
        public string Name => throw new NotImplementedException();

        public Weight Weight { get; } = new Weight(Randomizer.RandomInteger(1, 5));

        public Requirements Requirements => throw new NotImplementedException();

        public EquipableItemType Type => throw new NotImplementedException();

        public IEnumerable<IEnhancement<IStatistic>> Enhancements => throw new NotImplementedException();
    }
}