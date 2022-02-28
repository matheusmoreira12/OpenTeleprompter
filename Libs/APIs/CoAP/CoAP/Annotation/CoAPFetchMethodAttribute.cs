using System;

namespace OpenTeleprompter.APIs.CoAP.Annotation
{
    public sealed class CoAPFetchMethodAttribute : CoAPMethodAttribute
    {
        public CoAPFetchMethodAttribute() : base(CoAPMethodType.Fetch)
        {
        }
    }
}
