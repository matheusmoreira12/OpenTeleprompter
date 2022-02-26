using System.Collections.Generic;
using Cairo;
using OpenTeleprompter.Data;

namespace OpenTeleprompter.Rendering.Renderers
{
    public sealed class PageRenderer: DerivedRenderer<Page>
    {
        public PageRenderer(Page page, float renderY) : base(page)
        {
            RenderY = renderY;

            Initialize();
        }

        protected override IEnumerable<Renderer> CreateSubRenderers()
        {
            var textRenderer = new TextRenderer(Source.Text);
            yield return textRenderer;
        }

        public override void Render(Context context)
        {
            context.Save();

            context.Translate(0, RenderY);

            base.Render(context);

            context.Restore();
        }

        private readonly float RenderY;
    }
}
