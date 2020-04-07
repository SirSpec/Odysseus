namespace Odysseus.DomainModel.MapGenerator
{
    public interface IRandomNumberEngine
    {
        int RandomInteger(ConstraintRange<int> constraint);
        double RandomDouble(ConstraintRange<double> constraint);
    }
}