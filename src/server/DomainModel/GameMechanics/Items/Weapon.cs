using System.Collections.Generic;

namespace Odysseus.DomainModel.GameMechanics
{
    public class Weapon : IItem
    {
        public string Name { get; }
        public double Weight { get; }
        public Requirements Requirements { get; }
        public IEnumerable<IModifier<Statistic>> Modifiers { get; }
        public MeleeDamage Damage { get; }

        public Weapon(string name, double weight, Requirements requirements, IEnumerable<IModifier<Statistic>> modifiers, MeleeDamage damage) =>
            (Name, Weight, Requirements, Modifiers, Damage) = (name, weight, requirements, modifiers, damage);
    }
}