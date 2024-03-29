﻿namespace UnityFoundation.Code.Tests
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

        public IGrid<XY, int> Grid()
        {
            var grid = GridEmpty();

            var index = 0;
            foreach(var pos in grid.Limits.GetPositions())
                grid.SetValue(pos, index++);

            return grid;
        }

        public IGrid<XY, int> GridEmpty() => new GridXY<int>(limits);

        public XY OutOfGridCoordinate() => new(3, 3);

        public XY SecondCoordinate() => new(1, 0);
    }
}
