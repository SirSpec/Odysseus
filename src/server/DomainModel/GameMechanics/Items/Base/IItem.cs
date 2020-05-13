using Odysseus.DomainModel.GameMechanics.Inventory;

namespace Odysseus.DomainModel.GameMechanics.Items.Base
{
    public interface IItem
    {
        public string Name { get; }
        public Weight Weight { get; }
    }
}