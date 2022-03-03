using System;

namespace OpenTeleprompter.APIs.CoAP.Annotation
{
    public sealed class CoAPDeleteMethodAttribute : CoAPMethodAttribute
    {
        public CoAPDeleteMethodAttribute() : base(CoAPMethodType.Delete)
        {
        }
    }
}
