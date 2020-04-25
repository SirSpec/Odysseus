namespace Odysseus.DomainModel.GameMechanics
{
    public readonly struct Spell
    {
        public string Name { get; }
        public IModifier<IStatistic> Effect { get; }
        public Requirements Requirements { get; }

        public Spell(string name, IModifier<IStatistic> effect, Requirements requirements) =>
            (Name, Effect, Requirements) = (name, effect, requirements);
    }
}