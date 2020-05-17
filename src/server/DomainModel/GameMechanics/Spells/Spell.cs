using Odysseus.DomainModel.GameMechanics.Items;
using Odysseus.DomainModel.GameMechanics.Spells.Effects;

namespace Odysseus.DomainModel.GameMechanics.Spells
{
    public readonly struct Spell
    {
        public string Name { get; }
        public IEffect Effect { get; }
        public Requirements Requirements { get; }
        public int Cost { get; }

        public Spell(string name, IEffect effect, int cost, Requirements requirements) =>
            (Name, Effect, Cost, Requirements) = (name, effect, cost, requirements);
    }
}