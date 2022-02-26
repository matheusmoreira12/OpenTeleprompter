using System;
namespace OpenTeleprompter.Rendering
{
    public abstract class ValueConverter<Tin, Tout>
    {
        internal protected ValueConverter()
        {
        }

        public abstract Tout Convert(Tin value);

        public abstract Tout ConvertBack(Tin value);
    }
}
