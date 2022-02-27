using System;
namespace Data.Animations
{
    public abstract class AnimationEasingFunction
    {
        protected internal AnimationEasingFunction()
        {
        }

        public abstract double Apply(double value);
    }
}
