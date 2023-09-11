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

        public IGrid<XZ, int> GridEmpty() => new GridXZ<int>(limits);

        public virtual IGrid<XZ, int> Grid()
        {
            var grid = new GridXZ<int>(limits);
            grid.Clear();

            var index = 0;
            foreach(var pos in grid.Limits.GetPositions())
                grid.SetValue(pos, index++);

            return grid;
        }

        public XZ Coordinate() => new(0, 0);

        public XZ SecondCoordinate() => new(1, 0);

        public XZ OutOfGridCoordinate() => new(3, 3);
    }
}
