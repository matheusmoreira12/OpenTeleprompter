using Gdk;

namespace OpenTeleprompter.Rendering
{
    public abstract class Renderer<Tsource>
    {
        protected internal Renderer(Tsource source)
        {
            Source = source;
        }

        public abstract void Render(DrawingContext context);

        protected readonly Tsource Source;
    }
}
