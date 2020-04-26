namespace Odysseus.DomainModel.GameMechanics
{
    public class FlatModifier<TStatistic> : IModifier<TStatistic> where TStatistic : Statistic
    {
        private readonly int value;

        public FlatModifier(int value) =>
            this.value = value;

        public int Modify(int _) => value;
    }
}