namespace OpenTeleprompter.Data
{
    public struct Color
    {
        public Color(byte r, byte g, byte b)
        {
            R = r;
            G = g;
            B = b;
        }

        public readonly byte R;
        public readonly byte G;
        public readonly byte B;
    }
}