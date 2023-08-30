namespace UnityFoundation.Code.Tests
{
    public class XYFixture : IGridPositionFixture<XY>
    {
        public XY First => new(0, 0);
        public XY Second => new(0, 1);
        public XY Third => new(0, 2);
    }
}
