using Gdk;

namespace Rendering
{
    public abstract class Renderer<Tsource>
    {
        protected internal Renderer(Tsource source, DrawingContext drawingContext)
        {
            Source = source;
            DrawingContext = drawingContext;
        }

        protected readonly Tsource Source;

        protected readonly DrawingContext DrawingContext;
    }
}
