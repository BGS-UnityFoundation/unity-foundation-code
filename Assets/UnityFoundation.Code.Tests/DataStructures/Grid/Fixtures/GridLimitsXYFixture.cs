namespace UnityFoundation.Code.Tests
{
    public class GridLimitsXYFixture : IGridLimitsFixture<XY>
    {
        public IGridLimits<XY> Limits => new GridLimitXY(3, 3);

        public XY First => new(0, 0);

        public int FirstNeighboursCount => 2;

        public XY Central => new(1, 1);

        public int CentralNeighboursCount => 4;

        public XY CentralEdge => new(0, 1);

        public int CentralEdgeNeighboursCount => 3;
    }
}
