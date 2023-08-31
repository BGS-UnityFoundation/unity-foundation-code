namespace UnityFoundation.Code.Tests
{
    public class GridXYTestFixture : IGridTestFixture<XY, int>
    {
        private readonly GridLimitXY limits;

        public GridXYTestFixture()
        {
            limits = new GridLimitXY(2, 2);
        }

        public IGridLimits<XY> Limits => limits;

        public XY Coordinate() => new(0, 0);

        public IGrid<XY, int> Grid() => new GridXY<int>(limits);

        public XY OutOfGridCoordinate() => new(3, 3);

        public XY SecondCoordinate() => new(1, 0);
    }
}
