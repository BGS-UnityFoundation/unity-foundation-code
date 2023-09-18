using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityFoundation.Code;


namespace UnityFoundation.Code.Tests
{
    public class GridXYTests
    {
        [Test]
        public void Given_two_equals_coord_should_return_true()
        {
            var coord = new XY(0, 0);
            var coord2 = new XY(0, 0);

            Assert.That(coord.Equals(coord2), Is.True);
            Assert.That(coord == coord2, Is.True);
        }
    }
}
