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

            Assert.That(limits.GetIndex(fixture.First), Is.EqualTo(0));
            Assert.That(limits.GetIndex(fixture.First), Is.EqualTo(0));
            Assert.That(limits.GetIndex(fixture.First), Is.EqualTo(0));
        }

        [Test]
        public void Given_position_should_return_its_neighbours()
        {
            var limits = fixture.Limits;

            var cornerNeighbours = limits.GetNeighbours(fixture.First);

            Assert.That(
                cornerNeighbours.Length, 
                Is.EqualTo(fixture.FirstNeighboursCount)
            );

            var centralNeighours = limits.GetNeighbours(fixture.Central);

            Assert.That(
                centralNeighours.Length, 
                Is.EqualTo(fixture.CentralNeighboursCount)
            );

            var centralEdgeNeighours = limits.GetNeighbours(fixture.CentralEdge);

            Assert.That(
                centralEdgeNeighours.Length, 
                Is.EqualTo(fixture.CentralEdgeNeighboursCount)
            );
        }
    }
}
