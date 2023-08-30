using NUnit.Framework;
using System.Linq;

namespace UnityFoundation.Code.Tests
{
    public class GridXZLimitsTests
    {
        [Test]
        public void Should_identify_outside_positions()
        {
            GridXZLimits limits = new(1, 3);

            Assert.That(limits.IsInside(new(-1, -1)), Is.False);
            Assert.That(limits.IsInside(new(0, 3)), Is.False);
            Assert.That(limits.IsInside(new(1, 2)), Is.False);
        }

        [Test]
        public void Should_return_all_coordinates()
        {
            GridXZLimits limits = new(1, 3);

            foreach(var coord in limits.GetPositions())
                Assert.That(limits.IsInside(coord), Is.True);

            Assert.That(limits.GetPositions().Count(), Is.EqualTo(limits.PositionsCount));
        }
    }
}