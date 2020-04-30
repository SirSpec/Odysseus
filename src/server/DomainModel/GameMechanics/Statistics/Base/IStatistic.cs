using Odysseus.DomainModel.GameMechanics.Enhancements;

namespace Odysseus.DomainModel.GameMechanics.Statistics.Base
{
    public interface IStatistic
    {
        void AddEnhancement(IEnhancement<IStatistic> enhancement);
        void RemoveEnhancement(IEnhancement<IStatistic> enhancement);
    }
}