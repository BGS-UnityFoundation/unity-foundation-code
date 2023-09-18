using NUnit.Framework;

namespace UnityFoundation.Code.Timer.Tests
{
    public class TimerTests
    {
        [Test]
        public void Should_run_on_start()
        {
            var timer = new Timer(5f);
            timer.Start();

            Assert.That(timer.IsRunning, Is.True);
        }
    }
}