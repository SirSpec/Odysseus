namespace Odysseus.DomainModel.MapGenerator
{
    public interface IOffsettable<TValue>
    {
        TValue OffsetBy(Offset offset);
    }
}
