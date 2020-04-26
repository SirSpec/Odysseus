namespace Odysseus.DomainModel.GameMechanics
{
    public class FireDamage : Damage
    {
        public FireDamage() : base()
        {
        }

        public FireDamage(int value) : base(value)
        {
        }

        public FireDamage Scale(Intelligence intelligence) =>
            new FireDamage(Value + intelligence.Value);
    }
}