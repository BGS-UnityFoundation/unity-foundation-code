using NUnit.Framework;

namespace UnityFoundation.Code.Tests
{


    [TestFixture(typeof(GridLimitsXYFixture), typeof(XY))]
    public class GridLimitsTests<TLimits, TPos>
        where TLimits : IGridLimitsFixture<TPos>, new()
    {
        TLimits fixture;

        [SetUp]
        public void SetUp()
        {
            fixture = new TLimits();
        }

        [Test]
        public void Behaviour_index()
        {
            var limits = fixture.Limits;

            Assert.That(limits.GetIndex(fixture.Positions.First), Is.EqualTo(0));
            Assert.That(limits.GetIndex(fixture.Positions.First), Is.EqualTo(0));
            Assert.That(limits.GetIndex(fixture.Positions.First), Is.EqualTo(0));
        }
    }
}
