namespace UnityFoundation.Code.Tests
{
    public class GridLimitsXZFixture : IGridLimitsFixture<XZ>
    {
        public IGridLimits<XZ> Limits => new GridXZLimits(3, 3);

        public XZ First => new(0, 0);

        public int FirstNeighboursCount => 2;

        public XZ Central => new(1, 1);

        public int CentralNeighboursCount => 4;

        public XZ CentralEdge => new(0, 1);

        public int CentralEdgeNeighboursCount => 3;
    }
}