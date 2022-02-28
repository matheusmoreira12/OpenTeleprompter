using System;

namespace OpenTeleprompter.APIs.CoAP.Annotation
{
    [AttributeUsage(AttributeTargets.Method)]
    public abstract class CoAPMethodAttribute : Attribute
    {
        private readonly CoAPMethodType Type;

        protected internal CoAPMethodAttribute(CoAPMethodType type)
        {
            Type = type;
        }
    }
}
