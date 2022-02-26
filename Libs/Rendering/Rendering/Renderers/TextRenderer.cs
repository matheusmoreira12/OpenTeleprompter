using System;
using System.Collections.Generic;
using System.Linq;
using Cairo;
using OpenTeleprompter.Data;
using OpenTeleprompter.Rendering.ValueConverters;

namespace OpenTeleprompter.Rendering.Renderers
{
    public sealed class TextRenderer: DerivedRenderer<Text>
    {
        public TextRenderer(Text text): base(text)
        {
            Initialize();
        }

        protected override IEnumerable<Renderer> CreateSubRenderers()
        {
            var converter = new TextToStyledStringsConverter();
            var sstrs = converter.Convert(Text);

            float x = 0;
            float y = 0;

            foreach (var sstr in sstrs)
            {
                var renderer = new StyledStringRenderer(sstr, x, y);

                yield return renderer;

                x = renderer.RenderEndX;
                y = renderer.RenderEndY;
            }
        }

        public Text Text => Source;
    }
}