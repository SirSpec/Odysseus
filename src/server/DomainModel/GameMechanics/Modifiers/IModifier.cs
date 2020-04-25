namespace Odysseus.DomainModel.GameMechanics
{
    public interface IModifier<out TType> where TType : class, IStatistic, new()
    {
        IStatistic Modify(IStatistic statistic);
    }
}