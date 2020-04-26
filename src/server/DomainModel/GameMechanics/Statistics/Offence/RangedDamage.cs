namespace Odysseus.DomainModel.GameMechanics
{
    public class RangedDamage : Damage
    {
        public RangedDamage() : base()
        {
        }

        public RangedDamage(int value) : base(value)
        {
        }

        public RangedDamage Scale(Dexterity dexterity) =>
            new RangedDamage(Value + dexterity.Value);
    }
}