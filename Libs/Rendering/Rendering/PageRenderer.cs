using Cairo;
using OpenTeleprompter.Data;

namespace OpenTeleprompter.Rendering
{
    public sealed class PageRenderer: Renderer<Page>
    {
        public PageRenderer(Page page) : base(page)
        {
        }

        public override void Render(Context context)
        {
            var textRenderer = new TextRenderer(Page.Text);
        }

        public Page Page => Source;
    }
}
