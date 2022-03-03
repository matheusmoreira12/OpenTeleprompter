using System;

namespace OpenTeleprompter.APIs.CoAP.Annotation
{
    public sealed class CoAPPostMethodAttribute : CoAPMethodAttribute
    {
        public CoAPPostMethodAttribute() : base(CoAPMethodType.Post)
        {
        }
    }
}
