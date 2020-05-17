using Odysseus.DomainModel.GameMechanics.Enhancements;
using Odysseus.DomainModel.GameMechanics.Statistics.Base;

namespace Odysseus.DomainModel.GameMechanics.Spells.Effects
{
    public interface IBuff : IEffect
    {
        public IEnhancement<IStatistic> Enhancement { get; }
    }
}