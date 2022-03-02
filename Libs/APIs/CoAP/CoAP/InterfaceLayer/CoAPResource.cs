namespace OpenTeleprompter.APIs.CoAP.InterfaceLayer
{
    internal sealed class CoAPResource : Waher.Networking.CoAP.CoapResource
    {
        public CoAPResource(string Path,
            Waher.Networking.CoAP.ICoapGetMethod getMethod,
            Waher.Networking.CoAP.ICoapPutMethod putMethod,
            Waher.Networking.CoAP.ICoapPostMethod postMethod,
            Waher.Networking.CoAP.ICoapFetchMethod fetchMethod,
            Waher.Networking.CoAP.ICoapPatchMethod patchMethod,
            Waher.Networking.CoAP.ICoapDeleteMethod deleteMethod) : base(Path)
        {
            GetMethod = getMethod;
            PutMethod = putMethod;
            PostMethod = postMethod;
            FetchMethod = fetchMethod;
            PatchMethod = patchMethod;
            DeleteMethod = deleteMethod;
        }

        public new Waher.Networking.CoAP.ICoapGetMethod GetMethod { get; }
        public new Waher.Networking.CoAP.ICoapPutMethod PutMethod { get; }
        public new Waher.Networking.CoAP.ICoapPostMethod PostMethod { get; }
        public new Waher.Networking.CoAP.ICoapFetchMethod FetchMethod { get; }
        public new Waher.Networking.CoAP.ICoapPatchMethod PatchMethod { get; }
        public new Waher.Networking.CoAP.ICoapDeleteMethod DeleteMethod { get; }
    }
}
