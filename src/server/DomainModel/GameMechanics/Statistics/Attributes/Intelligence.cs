namespace Odysseus.DomainModel.GameMechanics
{
    public class Intelligence : CharacterAttribute
    {
        public static Intelligence Initial => new Intelligence();

        public Intelligence()
        {
        }

        public Intelligence(int value) : base(value)
        {
        }

        public override CharacterAttribute Increase() => new Intelligence(BaseValue + 1);
    }
}