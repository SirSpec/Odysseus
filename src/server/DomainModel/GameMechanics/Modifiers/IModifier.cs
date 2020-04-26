namespace Odysseus.DomainModel.GameMechanics
{
    public interface IModifier<out TStatistic> where TStatistic : Statistic
    {
        int Modify(int value);
    }
}