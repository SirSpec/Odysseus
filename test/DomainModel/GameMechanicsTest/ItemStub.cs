using Odysseus.DomainModel.GameMechanics.Inventory;
using Odysseus.DomainModel.GameMechanics.Items;
using Odysseus.Framework.Randomizer;
using System;

namespace Odysseus.DomainModel.GameMechanicsTest.Inventory
{
    public class ItemStub : IItem
    {
        public string Name => throw new NotImplementedException();

        public Weight Weight { get; } = new Weight(Randomizer.RandomInteger(1, 5));

        public Requirements Requirements => throw new NotImplementedException();

    }
}