namespace Odysseus.DomainModel.GameMechanics
{
    public class PercentageModifier<TStatistic> : IModifier<TStatistic> where TStatistic : Statistic
    {
        private readonly int percentage;

        public PercentageModifier(int percentage) =>
            this.percentage = percentage;

        public int Modify(int value) => value * percentage / 100;
    }
}