namespace UnityFoundation.Code.Tests
{
    public class GridLimitsXYFixture : IGridLimitsFixture<XY>
    {
        public IGridLimits<XY> Limits => new GridLimitXY(1, 3);

        public IGridPositionFixture<XY> Positions => new XYFixture();
    }
}
