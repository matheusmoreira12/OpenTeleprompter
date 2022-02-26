using System;
namespace Data.Animations
{
    public class AnimatedFloat : AnimatedValue<float>
    {
        private AnimatedFloat(float start, float end, TimeSpan transitionDuration) :
            base(start, end, transitionDuration)
        {
        }

        public AnimatedFloat(float current) : base(current, current, TimeSpan.Zero)
        {
        }

        public override float CalculateCurrent()
        {
            var elapsedTime = DateTime.Now - StartTime;
            float progress = (float)elapsedTime.Milliseconds / TransitionDuration.Milliseconds;
            return (1 - progress) * Start + progress * End;
        }

        public AnimatedFloat Update(float end) => new AnimatedFloat(Current, end, TransitionDuration);
    }
}
