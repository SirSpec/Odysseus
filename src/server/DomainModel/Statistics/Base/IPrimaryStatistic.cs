namespace Odysseus.DomainModel.Statistics.Base
{
    public interface IPrimaryStatistic : IStatistic
    {
        int Value { get; }
    }
}