namespace Odysseus.Framework.Randomizer
{
    public interface IRandomNumberEngine
    {
        int RandomInteger(ConstraintRange<int> constraint);
        double RandomDouble(ConstraintRange<double> constraint);
    }
}