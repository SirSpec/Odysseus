using Odysseus.DomainModel.GameMechanics.Statistics.Base;
using Odysseus.DomainModel.GameMechanics.Enhancements;
using Odysseus.DomainModel.GameMechanics.Items;

namespace Odysseus.DomainModel.GameMechanics
{
    public readonly struct Spell
    {
        public string Name { get; }
        public IEnhancement<IStatistic> Effect { get; }
        public Requirements Requirements { get; }

        public Spell(string name, IEnhancement<IStatistic> effect, Requirements requirements) =>
            (Name, Effect, Requirements) = (name, effect, requirements);
    }
}