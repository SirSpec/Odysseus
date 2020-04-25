namespace Odysseus.DomainModel.GameMechanics
{
    public interface IModifier<out TType> where TType : IStatistic
    {
        IStatistic Modify(IStatistic statistic);
    }
}