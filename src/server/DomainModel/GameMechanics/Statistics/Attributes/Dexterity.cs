namespace Odysseus.DomainModel.GameMechanics
{
    public class Dexterity : Attribute
    {
        public static Dexterity Initial => new Dexterity();

        public Dexterity()
        {
        }

        public Dexterity(int value) : base(value)
        {
        }

        public override Attribute Increase() => new Dexterity(BaseValue + 1);
    }
}