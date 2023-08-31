namespace UnityFoundation.Code.Tests
{
    public interface IGridTestFixture<TPosition, TValue>
    {
        IGridLimits<TPosition> Limits { get; }
        TPosition Coordinate();
        public abstract IGrid<TPosition, TValue> Grid();
        TPosition OutOfGridCoordinate();
        TPosition SecondCoordinate();
    }
}
