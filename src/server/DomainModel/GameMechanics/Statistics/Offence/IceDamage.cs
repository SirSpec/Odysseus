namespace Odysseus.DomainModel.GameMechanics
{
    public class IceDamage : Damage
    {
        public IceDamage() : base()
        {
        }

        public IceDamage(int value) : base(value)
        {
        }

        public IceDamage Scale(Intelligence intelligence) =>
            new IceDamage(Value + intelligence.Value);
    }
}