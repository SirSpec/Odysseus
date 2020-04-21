namespace Odysseus.DomainModel.GameMechanics
{
    public class Potion : Item
    {
        public Effect Effect { get; }

        public Potion(string name, int weight, Requirements requirements, Effect effect)
            : base(name, weight, requirements)
        {
            Effect = effect;
        }
    }
}