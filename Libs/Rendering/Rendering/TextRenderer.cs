using System;
using System.Linq;
using Cairo;
using OpenTeleprompter.Data;

namespace OpenTeleprompter.Rendering
{
    public sealed class TextRenderer: Renderer<Text>
    {
        private const char LINE_BREAK_CHARACTER = '\n';
        private const char CARRIAGE_RETURN_CHARACTER = '\r';

        public TextRenderer(Text text): base(text)
        {
        }

        public override void Render(Context context)
        {
            var characters = Text.Content;
            var characterStyles = Text.GetIndividualCharacterStyles();

            float x = 0;
            float y = 0;
            float lineHeight = 0;
            float lineBaseline = 0;
            for (int i = 0; i < characters.Length; i++)
            {
                var character = characters[i];

                bool isLineBreak = character == LINE_BREAK_CHARACTER;
                bool isSOFOrLineBreak = i == 0 || isLineBreak;
                if (isSOFOrLineBreak)
                    calculateLineHeightAndLineBaselineOffset(i);

                if (isLineBreak)
                {
                    breakLine();
                    continue;
                }
                    
                bool isCarriageReturn = character == CARRIAGE_RETURN_CHARACTER;
                if (isCarriageReturn)
                {
                    returnCarriage();
                    continue;
                }

                var characterStyle = characterStyles[i];
                var font = characterStyle.Font;
                var glyph = font.GetCharacterGlyph(character);

                float glyphScale = characterStyle.FontHeight / glyph.Size.Height;
                float characterWidth = glyph.Size.Width * glyphScale;

                renderHighlight(characterStyle, characterWidth);
                renderGlyph(glyph, characterStyle, glyphScale);

                advanceCarriage(characterWidth);
            }

            void calculateLineHeightAndLineBaselineOffset(int fromIndex)
            {
                lineHeight = 0;
                lineBaseline = 0;

                var charactersAndStyles = characters.Zip(characterStyles, Tuple.Create);
                foreach (var (character, style) in charactersAndStyles)
                {
                    bool isLineBreak = character == LINE_BREAK_CHARACTER;
                    if (isLineBreak)
                        break;

                    var fontHeight = style.FontHeight;
                    var baselineShift = style.BaselineShift;
                    var lineSpacing = style.LineSpacing;

                    float characterHeight = calculateCharacterHeight(fontHeight,
                        lineSpacing, baselineShift);
                    lineHeight = Math.Max(lineHeight, characterHeight);

                    float characterBaseline = calculateBaseline(fontHeight, lineSpacing);
                    lineBaseline = Math.Max(lineBaseline, characterBaseline);
                }

                float calculateCharacterHeight(float fontHeight, float lineSpacing,
                    float baselineShift) => fontHeight + lineSpacing + Math.Abs(baselineShift);

                float calculateBaseline(float fontHeight, float lineSpacing)
                    => fontHeight + lineSpacing / 2;
            }

            void breakLine() => y += lineHeight;

            void returnCarriage() => x = 0;

            void renderHighlight(TextStyleOptions style, float characterWidth)
            {
                if (style.IsHighlighed)
                {
                    var highlightColor = style.HighlightColor;
                    context.Rectangle(x, y, characterWidth, lineHeight);
                    context.SetSourceRGB(highlightColor.R, highlightColor.G, highlightColor.B);
                    context.Fill();
                }
            }

            void renderGlyph(FontGlyph glyph, TextStyleOptions style, float glyphScale)
            {
                var renderer = new GlyphRenderer(glyph, style);

                context.Save();

                context.Translate(x, y + lineBaseline);
                context.Scale(glyphScale, glyphScale);
                renderer.Render(context);

                context.Restore();
            }

            void advanceCarriage(float characterWidth) => x += characterWidth;
        }

        public Text Text => Source;
    }
}