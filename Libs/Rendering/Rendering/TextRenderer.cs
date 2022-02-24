using System;
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
            var characterStyles = Text.GetCharacterStyles();
            var characterAndStyles = Text.Characters.Zip(characterStyles, Tuple.Create);

            foreach ((byte character, TextStyleOptions style) in characterAndStyles)
            {
                if (character == (byte)'\n')
                {
                    advancePaperAndReturnCarriage();
                    continue;
                }

                // TODO: Render each character

                advanceCarriage(0);
                updateLineHeight(0);
            }

            void advancePaperAndReturnCarriage()
            {
                x = 0;
                y += lineHeight;
                lineHeight = 0;
            }

            void advanceCarriage(float charWidth) => x += charWidth;

            void updateLineHeight(float charHeight)
            {
                if (charHeight > lineHeight)
                    lineHeight = charHeight;
            }
        }

        public Text Text => Source;
    }
}