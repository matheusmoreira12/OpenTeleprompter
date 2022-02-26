using System;
namespace OpenTeleprompter.Data
{
    public sealed class Page
    {
        public Page(Text text, PageStyle style)
        {
            Text = text;
            Style = style;
        }

        public readonly Text Text;
        public readonly PageStyle Style;
    }
}
