using System;

namespace Data
{
    public sealed class DocumentReaderState
    {
        public int ScrollPage { get; private set; }

        public int ScrollLine { get; private set; }

        public event EventHandler ChangeEvent;

        public void SetScrollPage(int scrollPage)
        {
            ScrollPage = scrollPage;
            ChangeEvent.Invoke(this, new EventArgs());
        }

        public void SetScrollLine(int scrollLine)
        {
            ScrollLine = scrollLine;
            ChangeEvent.Invoke(this, new EventArgs());
        }
    }
}