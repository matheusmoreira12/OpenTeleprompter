using Cairo;

namespace OpenTeleprompter.Rendering
{
    public abstract class Renderer<Tsource>
    {
        protected internal Renderer(Tsource source)
        {
            Source = source;
        }

        public abstract void Render(Context context);

        protected readonly Tsource Source;
    }
}
