using System;

namespace OpenTeleprompter.APIs.CoAP.Annotation
{
    [AttributeUsage(AttributeTargets.Field)]
    public sealed class CoAPResourceAttribute : Attribute
    {
        public CoAPResourceAttribute(string path)
        {
            Path = new Uri(path);
        }

        public readonly Uri Path;
    }
}
