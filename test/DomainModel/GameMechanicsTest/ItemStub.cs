﻿using Odysseus.DomainModel.GameMechanics.Enhancements;
using Odysseus.DomainModel.GameMechanics.Inventory;
using Odysseus.DomainModel.GameMechanics.Items;
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

        public EquipableItemType Type => EquipableItemType.MainHand;

        public IEnumerable<IEnhancement<IStatistic>> Enhancements => new List<IEnhancement<IStatistic>>();
    }
}