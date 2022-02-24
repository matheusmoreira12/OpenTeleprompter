using System.Linq;
using Gdk;
using OpenTeleprompter.Data;

namespace OpenTeleprompter.Rendering
{
    public class TextRenderer: Renderer<Text>
    {
        public TextRenderer(Text text): base(text)
        {
        }

        public override void Render(DrawingContext context)
        {
            float x = 0;
            float y = 0;
            float lineHeight = 0;
            var format = Text.Style.Intervals[0].Options;

            for (int i = 0; i < Text.Characters.Length; i++)
            {
                var character = Text.Characters[i];

                if (character == (byte)'\n')
                {
                    x = 0;
                    y += lineHeight;
                    lineHeight = 0;
                    continue;
                }

                var glyph = format.Font.Glyphs.First(g=> g.Character == character);



                x += glyph.Size.Width;

                if (lineHeight < format.FontHeight)
                    lineHeight = format.FontHeight;
            }
        }

        public Text Text => Source;
    }
}