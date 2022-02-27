using System;
namespace OpenTeleprompter.Data.Animations
{
    public static class AnimationEasingFunctions
    {
        public static readonly AnimationEasingFunction Linear = (double x) => x;

        public static readonly AnimationEasingFunction EaseIn = (double x) =>
            x < .5 ? 4 * Math.Pow(x, 3) :  1 - 4 * Math.Pow(1 - x, 3);

        public static readonly AnimationEasingFunction EaseOut = (double x) => Math.Pow(x, 3);

        public static readonly AnimationEasingFunction Ease = (double x) => 1 - Math.Pow(1 - x, 3);
    }
}
