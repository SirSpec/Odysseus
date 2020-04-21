namespace Odysseus.DomainModel.GameMechanics
{
    public class Weapon : Item
    {
        public Damage Damage { get; }

        public Weapon(string name, int weight, Requirements requirements, Damage damage)
            : base(name, weight, requirements)
        {
            Damage = damage;
        }
    }
}