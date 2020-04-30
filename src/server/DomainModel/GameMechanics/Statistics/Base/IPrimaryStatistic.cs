namespace Odysseus.DomainModel.GameMechanics.Statistics.Base
{
    public interface IPrimaryStatistic : IStatistic
    {
        int Value { get; }
    }
}