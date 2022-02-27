using System;
namespace OpenTeleprompter.Data.Animations
{
    public static class AnimationEasingFunctions
    {
        public const double EASING_EXPONENT = 5;

        public static readonly AnimationEasingFunction Linear = (double x) => x;

        public static readonly AnimationEasingFunction EaseIn = (double x) =>
            x < .5 ? Math.Pow(2 * x, EASING_EXPONENT) / 2 :
                1 - Math.Pow(2 * (1 - x), EASING_EXPONENT) / 2;

        public static readonly AnimationEasingFunction EaseOut = (double x) =>
            Math.Pow(x, EASING_EXPONENT);

        public static readonly AnimationEasingFunction Ease = (double x) =>
            1 - Math.Pow(1 - x, EASING_EXPONENT);
    }
}
