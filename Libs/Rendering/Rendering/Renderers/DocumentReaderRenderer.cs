using System;
using System.Collections.Generic;
using Cairo;
using OpenTeleprompter.Data;

namespace OpenTeleprompter.Rendering.Renderers
{
    public class DocumentReaderRenderer : DerivedRenderer<DocumentReader>
    {
        public DocumentReaderRenderer(DocumentReader source, Data.Size destSize) : base(source)
        {
            DestSize = destSize;

            Initialize();
        }

        public override void Render(Context context)
        {
            context.Save();

            var openDocument = Source.State.OpenDocument;

            if (openDocument == null)
                return;

            context.Rectangle(0, 0, DestSize.Width, DestSize.Height);
            context.SetSource(openDocument.PageStyle.BackgroundColor);
            context.Fill();

            var pageSize = openDocument.PageSize;
            context.AlignCenter(pageSize, DestSize);

            context.Translate(0, pageSize.Height / 2);

            context.NewPath();
            context.MoveTo(-44, -20);
            context.LineTo(-10, 0);
            context.LineTo(-44, 20);
            context.ClosePath();
            context.SetSourceRGB(255, 255, 255);
            context.Fill();

            context.Translate(0, -Source.State.ScrollY);

            base.Render(context);

            context.Restore();
        }

        protected override IEnumerable<Renderer> CreateSubRenderers()
        {
            var openDocumentRenderer = new DocumentRenderer(Source.State.OpenDocument);
            yield return openDocumentRenderer;
        }

        protected readonly Data.Size DestSize;
    }
}
