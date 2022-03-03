using System;

namespace OpenTeleprompter.APIs.CoAP.Annotation
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property,
        AllowMultiple = false)]
    public sealed class CoAPResourceAttribute : Attribute
    {
    }
}
