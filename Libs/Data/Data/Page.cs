using System;
namespace OpenTeleprompter.Data
{
    public class Page
    {
        public Page(Text text)
        {
            Text = text;
        }

        public readonly Text Text;
    }
}
