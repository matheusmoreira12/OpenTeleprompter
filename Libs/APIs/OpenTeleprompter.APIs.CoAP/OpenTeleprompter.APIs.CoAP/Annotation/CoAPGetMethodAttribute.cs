using System;

namespace OpenTeleprompter.APIs.CoAP.Annotation
{
    public sealed class CoAPGetMethodAttribute : CoAPMethodAttribute
    {
        public CoAPGetMethodAttribute() : base(CoAPMethodType.Get)
        {
        }
    }
}
