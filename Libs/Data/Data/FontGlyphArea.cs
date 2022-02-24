namespace OpenTeleprompter.Data
{
    public class FontGlyphArea
    {
        public FontGlyphArea(Point[] contour, bool mode)
        {
            Contour = contour;
            Mode = mode;
        }

        public readonly Point[] Contour;
        public readonly bool Mode;
    }
}