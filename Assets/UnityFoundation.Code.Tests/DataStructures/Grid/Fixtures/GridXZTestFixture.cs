namespace UnityFoundation.Code.Tests
{
    public class GridXZTestFixture : IGridTestFixture<XZ, int>
    {
        private readonly GridXZLimits limits;

        public GridXZTestFixture()
        {
            limits = new GridXZLimits(2, 2);
        }

        public IGridLimits<XZ> Limits => limits;

        public virtual IGrid<XZ, int> Grid()
        {
            return new BaseGrid<GridXZLimits, GridCell<int>, XZ, int>(limits);
        }

        public XZ Coordinate() => new(0, 0);

        public XZ SecondCoordinate() => new(1, 0);

        public XZ OutOfGridCoordinate() => new(3, 3);
    }
}
