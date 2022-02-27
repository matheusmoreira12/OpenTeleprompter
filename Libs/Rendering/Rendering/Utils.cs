using System;
using Cairo;

namespace OpenTeleprompter.Rendering
{
    public static class Utils
    {
        public static void AlignCenter(this Context context, Data.Size sourceSize, Data.Size destSize)
        {
            float scale = Math.Min(destSize.Width / sourceSize.Width,
                destSize.Height / sourceSize.Height);

            float finalWidth = sourceSize.Width * scale;
            float finalHeight = sourceSize.Height * scale;

            float offsetX = (destSize.Width - finalWidth) / 2,
                offsetY = (destSize.Height - finalHeight) / 2;

            context.Translate(offsetX, offsetY);
            context.Scale(scale, scale);
        }

        public static void SetSource(this Context context, Data.Color color)
        {
            context.SetSourceRGB(color.R, color.G, color.B);
            context.Fill();
        }
    }
}
