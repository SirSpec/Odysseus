namespace Odysseus.DomainModel.GameMechanics
{
    public class Strength : CharacterAttribute
    {
        public static Strength Initial => new Strength();

        public Strength()
        {
        }

        public Strength(int value) : base(value)
        {
        }

        public override CharacterAttribute Increase() => new Strength(BaseValue + 1);
    }
}