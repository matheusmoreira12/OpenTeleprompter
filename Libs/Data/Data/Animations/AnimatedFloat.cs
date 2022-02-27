using System;
namespace OpenTeleprompter.Data.Animations
{
    public class AnimatedFloat : AnimatedValue<float>
    {
        private AnimatedFloat(float start, float end, TimeSpan duration,
            AnimationEasingFunction easingFunction) :
                base(start, end, duration, easingFunction)
        {
        }

        public AnimatedFloat(float current, TimeSpan duration,
            AnimationEasingFunction easingFunction) :
                base(current, current, duration, easingFunction)
        {
        }

        public override float CalculateCurrent(double progress) =>
            (float)((1 - progress) * Start + progress * End);

        public AnimatedFloat Update(float end) => new AnimatedFloat(Current,
            end, Duration, EasingFunction);
    }
}
