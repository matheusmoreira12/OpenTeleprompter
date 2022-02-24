using Gdk;
using OpenTeleprompter.Data;

namespace OpenTeleprompter.Rendering
{
    public class PageRenderer: Renderer<Page>
    {
        public PageRenderer(Page page) : base(page)
        {
        }

        public override void Render(DrawingContext context)
        {
            var textRenderer = new TextRenderer(Page.Text);
        }

        public Page Page => Source;
    }
}
