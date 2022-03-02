using System;

namespace OpenTeleprompter.APIs.CoAP.Annotation
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public abstract class CoAPMethodAttribute : Attribute
    {
        protected internal CoAPMethodAttribute(CoAPMethodType type)
        {
            Type = type;
        }

        private readonly CoAPMethodType Type;
    }
}
