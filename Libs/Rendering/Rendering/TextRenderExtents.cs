using System;
using OpenTeleprompter.Data;

namespace OpenTeleprompter.Rendering
{
    public struct TextRenderExtents
    {
        public TextRenderExtents(float advanceX, float advanceY, float width, float height)
        {
            AdvanceX = advanceX;
            AdvanceY = advanceY;
            Width = width;
            Height = height;
        }

        public Size ToSize() => new Size(Width, Height);

        public readonly float AdvanceX;
        public readonly float AdvanceY;
        public readonly float Width;
        public readonly float Height;
    }
}
