using System;
using System.Collections.Generic;
using Cairo;
using OpenTeleprompter.Data;
using Rendering.StyledText;

namespace OpenTeleprompter.Rendering.Renderers
{
    public class StyledStringRenderer : DerivedRenderer<StyledString>
    {
        private const char LINE_BREAK_CHARACTER = '\n';
        private const char CARRIAGE_RETURN_CHARACTER = '\r';

        public StyledStringRenderer(StyledString source, float renderStartX,
            float renderStartY) : base(source)
        {
            RenderStartX = renderStartX;
            RenderStartY = renderStartY;
        }

        public override void Render(Context context) {
            context.Save();

            var textColor = Source.Style.TextColor;
            context.SetSourceRGB(textColor.R, textColor.G, textColor.B);

            base.Render(context);

            context.Restore();
        }

        private readonly float RenderStartX;
        private readonly float RenderStartY;
        public float RenderEndX { get; private set; }
        public float RenderEndY { get; private set; }

        protected override IEnumerable<Renderer> CreateSubRenderers()
        {
            var font = Source.Style.Font;
            var srcStr = Source.ToString();

            float x = RenderStartX;
            float y = RenderStartY;

            foreach (var @char in srcStr)
            {
                if (@char == LINE_BREAK_CHARACTER)
                {
                    y += font.Height;
                    continue;
                }

                if (@char == CARRIAGE_RETURN_CHARACTER)
                {
                    x = 0;
                    continue;
                }

                var glyph = font.GetCharacterGlyph(@char);
                var renderer = new GlyphRenderer(glyph, x, y);
                yield return renderer;

                x += glyph.Width;
            }

            RenderEndX = x;
            RenderEndY = y;
        }
    }
}
