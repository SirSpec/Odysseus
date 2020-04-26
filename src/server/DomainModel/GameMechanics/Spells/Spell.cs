namespace Odysseus.DomainModel.GameMechanics
{
    public readonly struct Spell
    {
        public string Name { get; }
        public IModifier<Statistic> Effect { get; }
        public Requirements Requirements { get; }

        public Spell(string name, IModifier<Statistic> effect, Requirements requirements) =>
            (Name, Effect, Requirements) = (name, effect, requirements);
    }
}