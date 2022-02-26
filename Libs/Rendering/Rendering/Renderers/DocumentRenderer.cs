using System;
using System.Collections.Generic;
using OpenTeleprompter.Data;

namespace OpenTeleprompter.Rendering.Renderers
{
    public class DocumentRenderer : DerivedRenderer<Document>
    {
        public DocumentRenderer(Document source) : base(source)
        {
            Initialize();
        }

        protected override IEnumerable<Renderer> CreateSubRenderers()
        {
            var pageHeight = Source.PageSize.Height;

            float y = 0;

            foreach (var page in Source.Pages)
            {
                var renderer = new PageRenderer(page, y);
                yield return renderer;

                y += pageHeight;
            }
        }
    }
}
