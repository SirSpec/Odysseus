namespace Odysseus.DomainModel.GameMechanics
{
    public class Armor : Item
    {
        public int Value { get; }

        public Armor(string name, int weight, Requirements requirements, int value)
            : base(name, weight, requirements)
        {
            Value = value;
        }
    }
}