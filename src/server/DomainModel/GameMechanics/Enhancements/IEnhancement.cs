using Odysseus.DomainModel.GameMechanics.Statistics.Base;

namespace Odysseus.DomainModel.GameMechanics.Enhancements
{
    public interface IEnhancement<out TEnhanceable> where TEnhanceable : class, IStatistic
    {
        int Enhance(int value);
    }
}