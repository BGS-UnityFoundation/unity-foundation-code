namespace UnityFoundation.Code.Tests
{
    public interface IGridLimitsFixture<TPosition>
    {
        public IGridLimits<TPosition> Limits { get; }

        TPosition First { get; }
        int FirstNeighboursCount { get; }

        TPosition Central { get; }
        int CentralNeighboursCount { get; }

        TPosition CentralEdge { get; }
        int CentralEdgeNeighboursCount { get; }
    }
}
