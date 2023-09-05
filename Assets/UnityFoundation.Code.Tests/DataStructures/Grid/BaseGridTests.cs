using NUnit.Framework;
using System.Linq;

namespace UnityFoundation.Code.Tests
{
    public class BaseGridTests
    {
        class TestValue
        {
            public string str;
        }

        [Test]
        public void Given_position_is_filled_should_update_value()
        {
            var grid = new BaseGrid<GridXZLimits, GridCell<TestValue>, XZ, TestValue>(
                new GridXZLimits(2, 2)
            );

            var coord = new XZ(0, 0);
            grid.UpdateValue(coord, value => value.str = "updated");

            Assert.That(grid.GetValue(coord).str, Is.EqualTo("updated"));
        }

        [Test]
        public void Should_return_all_grid_values()
        {
            var grid = new BaseGrid<GridXZLimits, GridCell<TestValue>, XZ, TestValue>(
                new GridXZLimits(2, 2)
            );

            Assert.That(grid.GetValues().Count(), Is.EqualTo(4));
        }

        [Test]
        public void Given_value_should_return_coord()
        {
            var grid = new BaseGrid<GridXZLimits, GridCell<TestValue>, XZ, TestValue>(
                new GridXZLimits(2, 2)
            );

            var coord = new XZ(0, 0);
            var anyTestValue = new TestValue();

            grid.SetValue(coord, anyTestValue);

            var outputPosition = grid.GetPosition(anyTestValue);
                        
            Assert.That(outputPosition, Is.EqualTo(coord),
                $"GetPosition {outputPosition} should be equals {coord}");            

        }

        [Test]
        public void Given_value_not_present_in_grid_return_default()
        {
            var grid = new BaseGrid<GridXZLimits, GridCell<TestValue>, XZ, TestValue>(
                new GridXZLimits(2, 2)
            );
                        
            var outputPosition = grid.GetPosition(new TestValue());

            Assert.That(outputPosition, Is.EqualTo(default));
        }
    }
}
