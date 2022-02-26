using System.Collections.Generic;
using Cairo;
using OpenTeleprompter.Data;

namespace OpenTeleprompter.Rendering.Renderers
{
    public sealed class PageRenderer: DerivedRenderer<Page>
    {
        public PageRenderer(Page page) : base(page)
        {
            Initialize();
        }

        protected override IEnumerable<Renderer> CreateSubRenderers()
        {
            var textRenderer = new TextRenderer(Page.Text);
            yield return textRenderer;
        }

        public Page Page => Source;
    }
}
