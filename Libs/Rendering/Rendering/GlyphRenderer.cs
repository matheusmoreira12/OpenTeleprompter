using System.Linq;
using Cairo;
using OpenTeleprompter.Data;

namespace OpenTeleprompter.Rendering
{
    public sealed class GlyphRenderer : Renderer<FontGlyph>
    {
        public GlyphRenderer(FontGlyph glyph, TextStyleOptions style) : base(glyph)
        {
            Style = style;
        }

        public override void Render(Context context)
        {
            context.Save();

            context.FillRule = FillRule.EvenOdd;

            applyBaselineShift();           
            appendPathFromGlyph();
            applyTextColor();
            context.Fill();

            void applyBaselineShift() =>
                context.Translate(0, -Style.BaselineShift);

            void appendPathFromGlyph()
            {
                context.NewPath();

                appendSubPathFromArea();

                context.ClosePath();

                void appendSubPathFromArea()
                {
                    foreach (var area in Glyph.Areas)
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
                }
            }

            void applyTextColor()
            {
                var textColor = Style.TextColor;
                context.SetSourceRGB(textColor.R, textColor.G, textColor.B);
            }

            context.Restore();
        }

        public FontGlyph Glyph => Source;

        private readonly TextStyleOptions Style;
    }
}
