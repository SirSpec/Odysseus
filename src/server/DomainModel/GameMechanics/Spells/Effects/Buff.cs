using Odysseus.DomainModel.GameMechanics.Enhancements;
using Odysseus.DomainModel.GameMechanics.Statistics.Base;

namespace Odysseus.DomainModel.GameMechanics.Spells.Effects
{
    public readonly struct Buff : IBuff
    {
        public string Name { get; }
        public IEnhancement<IStatistic> Enhancement { get; }

        public Buff(string name, IEnhancement<IStatistic> enhancement) =>
            (Name, Enhancement) = (name, enhancement);
    }
}