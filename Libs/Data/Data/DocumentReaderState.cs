using System;
using OpenTeleprompter.Data.Animations;

namespace OpenTeleprompter.Data
{
    public sealed class DocumentReaderState
    {
        private static readonly TimeSpan TRANSITION_TIME = TimeSpan.FromSeconds(1);
        private static readonly AnimationEasingFunction EASING_FUNCTION = AnimationEasingFunctions.Ease;

        public float ScrollY {
            get => AnimatedScrollY.Current;
            set => AnimatedScrollY = AnimatedScrollY.Update(value);
        }
        private AnimatedFloat AnimatedScrollY = new AnimatedFloat(0, TRANSITION_TIME, EASING_FUNCTION);

        public Document OpenDocument
        {
            get => _OpenDocument;
            set
            {
                _OpenDocument = value;
                Invoke_OnOpenDocumentChange();
            }
        }
        private Document _OpenDocument;

        private void Invoke_OnOpenDocumentChange()
        {
            OpenDocumentChangeEvent.Invoke(this, new EventArgs());
        }

        public event EventHandler OpenDocumentChangeEvent = new EventHandler(OnOpenDocumentChange);

        private static void OnOpenDocumentChange(object sender, EventArgs e)
        {
        }
    }
}