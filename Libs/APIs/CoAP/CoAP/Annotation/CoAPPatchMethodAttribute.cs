using System;

namespace OpenTeleprompter.APIs.CoAP.Annotation
{
    public sealed class CoAPPatchMethodAttribute : CoAPMethodAttribute
    {
        public CoAPPatchMethodAttribute() : base(CoAPMethodType.Patch)
        {
        }
    }
}
