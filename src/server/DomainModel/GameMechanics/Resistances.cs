namespace Odysseus.DomainModel.GameMechanics
{
    public readonly struct Resistances
    {
        private const int MaximumResistance = 70;

        public int UncappedFire { get; }
        public int UncappedIce { get; }
        public int UncappedLightning { get; }

        public int Fire { get; }
        public int Ice { get; }
        public int Lightning { get; }

        public Resistances(int uncappedFire, int uncappedIce, int uncappedLightning)
        {
            (UncappedFire, UncappedIce, UncappedLightning) = (uncappedFire, uncappedIce, uncappedLightning);
            Fire = CalculateResistance(uncappedFire);
            Ice = CalculateResistance(uncappedIce);
            Lightning = CalculateResistance(uncappedLightning);
        }

        private static int CalculateResistance(int uncappedValue) =>
            uncappedValue >= MaximumResistance ? MaximumResistance : uncappedValue;
    }
}
