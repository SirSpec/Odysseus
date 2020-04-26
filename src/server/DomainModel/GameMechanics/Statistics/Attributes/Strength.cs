namespace Odysseus.DomainModel.GameMechanics
{
    public class Strength : Attribute
    {
        public static Strength Initial => new Strength();

        public Strength()
        {
        }

        public Strength(int value) : base(value)
        {
        }

        public override Attribute Increase() => new Strength(BaseValue + 1);
    }
}