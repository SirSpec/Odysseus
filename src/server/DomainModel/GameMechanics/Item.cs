namespace Odysseus.DomainModel.GameMechanics
{
    public abstract class Item
    {
        public string Name { get; }
        public double Weight { get; }
        public Requirements Requirements { get; }

        public Item(string name, double weight, Requirements requirements) =>
            (Name, Weight, Requirements) = (name, weight, requirements);
    }
}