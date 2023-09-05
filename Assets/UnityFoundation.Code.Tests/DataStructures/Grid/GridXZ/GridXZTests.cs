using NUnit.Framework;
using System.Linq;

namespace UnityFoundation.Code.Tests
{
    public class GridXZTests
    {
        [Test]
        public void Given_two_equals_coord_should_return_true()
        {
            var coord = new XZ(0, 0);
            var coord2 = new XZ(0, 0);

            Assert.That(coord.Equals(coord2), Is.True);
            
        }
    }
}

