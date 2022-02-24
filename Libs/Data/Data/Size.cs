namespace OpenTeleprompter.Data
{
    public struct Size
    {
        public Size(float width, float height)
        {
            Width = width;
            Height = height;
        }

        public readonly float Width;
        public readonly float Height;
    }
}