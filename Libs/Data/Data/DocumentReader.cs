using System;
using Data.Animations;

namespace Data
{
    public sealed class DocumentReader
    {
        public DocumentReader(DocumentReaderState state, float scrollY)
        {
            State = state;
            ScrollY = new AnimatedFloat(scrollY);
        }

        public readonly DocumentReaderState State;
        public readonly AnimatedFloat ScrollY;
    }
}
