using System;
namespace OpenTeleprompter.Data.Animations
{
    public abstract class AnimatedValue<Tvalue>
    {
        protected internal AnimatedValue(Tvalue start, Tvalue end, TimeSpan duration,
            AnimationEasingFunction easingFunction)
        {
            Start = start;
            End = end;
            StartTime = DateTime.Now;
            EasingFunction = easingFunction ??
                throw new ArgumentNullException(nameof(easingFunction));
            Duration = duration;
        }

        public Tvalue Current
        {
            get
            {
                var now = DateTime.Now;
                if (now <= StartTime)
                    return Start;

                var endTime = StartTime + Duration;
                if (now >= endTime)
                    return End;

                var elapsedTime = DateTime.Now - StartTime;
                double progress = elapsedTime.Ticks / (double)Duration.Ticks;
                double easedProgress = EasingFunction(progress);
                return CalculateCurrent(easedProgress);
            }
        }

        public abstract Tvalue CalculateCurrent(double progress);

        protected readonly AnimationEasingFunction EasingFunction;
        protected readonly Tvalue Start;
        protected readonly Tvalue End;
        protected readonly DateTime StartTime;
        protected readonly TimeSpan Duration;
    }
}
