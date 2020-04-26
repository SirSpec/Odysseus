namespace Odysseus.DomainModel.GameMechanics
{
    public class MeleeDamage : Damage
    {
        public MeleeDamage() : base()
        {
        }

        public MeleeDamage(int value) : base(value)
        {
        }

        public MeleeDamage Scale(Strength strength) =>
            new MeleeDamage(Value + strength.Value);
    }
}