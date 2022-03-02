using System;

namespace OpenTeleprompter.APIs.CoAP.Annotation
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public sealed class CoAPResourceAttribute : Attribute
    {
    }
}
