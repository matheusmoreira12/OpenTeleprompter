using System;
namespace Data.Animations
{
    public abstract class AnimatedValue<Tvalue>
    {
        protected internal AnimatedValue(Tvalue start, Tvalue end, TimeSpan transitionDuration)
        {
            Start = start;
            End = end;
            StartTime = DateTime.Now;
            TransitionDuration = transitionDuration;
        }

        public Tvalue Current
        {
            get
            {
                var now = DateTime.Now;
                var endTime = StartTime + TransitionDuration;
                if (now < StartTime)
                    return Start;
                if (now > endTime)
                    return End;
                return CalculateCurrent();
            }
        }

        public abstract Tvalue CalculateCurrent();

        protected readonly Tvalue Start;
        protected readonly Tvalue End;
        protected readonly DateTime StartTime;
        protected readonly TimeSpan TransitionDuration;
    }
}
