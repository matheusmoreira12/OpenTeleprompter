using Cairo;
using OpenTeleprompter.Data;

namespace OpenTeleprompter.Rendering.Renderers
{
    public sealed class GlyphRenderer : Renderer<FontGlyph>
    {
        public GlyphRenderer(FontGlyph source, float x, float y) : base(source)
        {
            X = x;
            Y = y;
        }

        public override void Render(Context context)
        {
            context.Save();

            context.FillRule = FillRule.EvenOdd;

            context.Translate(X, Y);

            context.NewPath();

            foreach (var area in Source.Areas)
            {
                context.NewSubPath();

                var contour = area.Contour;

                if (area.Contour.Length == 0)
                    continue;

                for (int i = 0; i < contour.Length; i++)
                {
                    var point = contour[i];
                    if (i == 0)
                        context.MoveTo(point.X, -point.Y);
                    else
                        context.LineTo(point.X, -point.Y);
                }

                context.ClosePath();
            }

            context.ClosePath();

            context.Fill();

            context.Restore();
        }

        public readonly float X;
        public readonly float Y;
    }
}
