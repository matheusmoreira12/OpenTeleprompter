namespace OpenTeleprompter.Data
{
    public sealed class DocumentReader
    {
        public DocumentReader()
        {
            State = new DocumentReaderState();
        }

        public readonly DocumentReaderState State;
    }
}
