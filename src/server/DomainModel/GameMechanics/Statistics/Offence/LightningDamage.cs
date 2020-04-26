namespace Odysseus.DomainModel.GameMechanics
{
    public class LightningDamage : Damage
    {
        public LightningDamage() : base()
        {
        }

        public LightningDamage(int value) : base(value)
        {
        }

        public LightningDamage Scale(Intelligence intelligence) =>
            new LightningDamage(Value + intelligence.Value);
    }
}