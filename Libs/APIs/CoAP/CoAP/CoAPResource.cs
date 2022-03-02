using System;
namespace OpenTeleprompter.APIs.CoAP
{
    public class CoAPResource
    {
        public CoAPResource(Uri path)
        {
            Path = path;
        }

        public readonly Uri Path;
    }
}
