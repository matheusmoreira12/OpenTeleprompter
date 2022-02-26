using System;
using System.Collections.Generic;
using System.Linq;
using Cairo;

namespace OpenTeleprompter.Rendering
{
    public abstract class DerivedRenderer<Tsource> : Renderer<Tsource>
    {
        protected internal DerivedRenderer(Tsource source) : base(source)
        {
            SubRenderers = CreateSubRenderers().ToArray();
        }

        protected abstract IEnumerable<Renderer> CreateSubRenderers();

        public override void Render(Context context)
        {
            foreach (var subRenderer in SubRenderers)
                subRenderer.Render(context);
        }

        public readonly Renderer[] SubRenderers;
    }
}
