namespace Odysseus.DomainModel.GameMechanics
{
    public class Dexterity : CharacterAttribute
    {
        public static Dexterity Initial => new Dexterity();

        public Dexterity()
        {
        }

        public Dexterity(int value) : base(value)
        {
        }

        public override CharacterAttribute Increase() => new Dexterity(BaseValue + 1);
    }
}