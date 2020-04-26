namespace Odysseus.DomainModel.GameMechanics
{
    public class Intelligence : Attribute
    {
        public static Intelligence Initial => new Intelligence();

        public Intelligence()
        {
        }

        public Intelligence(int value) : base(value)
        {
        }

        public override Attribute Increase() => new Intelligence(BaseValue + 1);
    }
}