namespace UnityFoundation.Code.Tests
{
    public interface IGridLimitsFixture<TPosition>
    {
        public IGridLimits<TPosition> Limits { get; }

        public IGridPositionFixture<TPosition> Positions { get; }
    }
}
