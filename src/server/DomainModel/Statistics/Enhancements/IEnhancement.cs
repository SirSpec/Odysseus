using Odysseus.DomainModel.Statistics.Base;

namespace Odysseus.DomainModel.Statistics.Enhancements
{
    public interface IEnhancement<out TEnhanceable> where TEnhanceable : class, IStatistic
    {
        int Enhance(int value);
    }
}