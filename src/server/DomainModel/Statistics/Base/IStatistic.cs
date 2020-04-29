using Odysseus.DomainModel.Statistics.Enhancements;

namespace Odysseus.DomainModel.Statistics.Base
{
    public interface IStatistic
    {
        void AddEnhancement(IEnhancement<IStatistic> enhancement);
        void RemoveEnhancement(IEnhancement<IStatistic> enhancement);
    }
}