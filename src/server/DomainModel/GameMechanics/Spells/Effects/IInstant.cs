namespace Odysseus.DomainModel.GameMechanics.Spells.Effects
{
    public interface IInstant<TValue> : IEffect
    {
        public TValue Value { get; }
    }
}