namespace OpenTeleprompter.Data.Fonts
{
    public sealed class FontGlyphArea
    {
        public FontGlyphArea(Point[] contour)
        {
            Contour = contour;
        }

        public readonly Point[] Contour;
    }
}