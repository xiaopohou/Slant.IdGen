using System;
using System.Threading;

namespace IdGen.Tests
{
    public class MockTimeSource : ITimeSource
    {
        private long _current;

        public MockTimeSource()
            : this(0) { }

        public MockTimeSource(long current)
            : this(current, TimeSpan.FromMilliseconds(1)) { }

        public MockTimeSource(TimeSpan tickDuration)
            : this(0, tickDuration) { }

        public MockTimeSource(long current, TimeSpan tickDuration)
        {
            _current = current;
            TickDuration = tickDuration;
        }

        public DateTimeOffset Epoch => DateTimeOffset.MinValue;

        public TimeSpan TickDuration { get; }

        public long GetTicks()
        {
            return _current;
        }

        public void NextTick()
        {
            Interlocked.Increment(ref _current);
        }

        public void PreviousTick()
        {
            Interlocked.Decrement(ref _current);
        }
    }
}
