namespace Odysseus.DomainModel.GameMechanics
{
    public class Health : EnergyPool
    {
        public Health(int total) : base(total)
        {
        }

        public Health(int current, int total) : base(current, total)
        {
        }
    }
}
