using System;

namespace OpenTeleprompter.APIs.CoAP.Annotation
{
    public sealed class CoAPPutMethodAttribute : CoAPMethodAttribute
    {
        public CoAPPutMethodAttribute() : base(CoAPMethodType.Put)
        {
        }
    }
}
