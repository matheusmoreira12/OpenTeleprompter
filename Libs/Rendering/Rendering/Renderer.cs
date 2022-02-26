using Cairo;

namespace OpenTeleprompter.Rendering
{
    public abstract class Renderer
    {
        public abstract void Render(Context context);
    }

    public abstract class Renderer<Tsource> : Renderer
    {
        protected internal Renderer(Tsource source)
        {
            Source = source;
        }

        public readonly Tsource Source;
    }
}
