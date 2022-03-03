using System.Threading.Tasks;

namespace OpenTeleprompter.APIs.CoAP.InterfaceLayer
{
    internal sealed class CoAPResource : Waher.Networking.CoAP.CoapResource,
        Waher.Networking.CoAP.ICoapGetMethod, Waher.Networking.CoAP.ICoapPutMethod,
        Waher.Networking.CoAP.ICoapPostMethod, Waher.Networking.CoAP.ICoapFetchMethod,
        Waher.Networking.CoAP.ICoapPatchMethod, Waher.Networking.CoAP.ICoapDeleteMethod
    {
        public CoAPResource(string path, CoAPMethod get, CoAPMethod put,
            CoAPMethod post, CoAPMethod fetch, CoAPMethod patch,
            CoAPMethod delete) : base(path)
        {
            Get = get;
            Put = put;
            Post = post;
            Fetch = fetch;
            Patch = patch;
            Delete = delete;
        }

        public Task GET(Waher.Networking.CoAP.CoapMessage Request,
            Waher.Networking.CoAP.CoapResponse Response) => Get(Request, Response);

        public Task PUT(Waher.Networking.CoAP.CoapMessage Request,
            Waher.Networking.CoAP.CoapResponse Response) => Put(Request, Response);

        public Task POST(Waher.Networking.CoAP.CoapMessage Request,
            Waher.Networking.CoAP.CoapResponse Response) => Post(Request, Response);

        public Task FETCH(Waher.Networking.CoAP.CoapMessage Request,
            Waher.Networking.CoAP.CoapResponse Response) => Fetch(Request, Response);

        public Task PATCH(Waher.Networking.CoAP.CoapMessage Request,
            Waher.Networking.CoAP.CoapResponse Response) => Patch(Request, Response);

        public Task DELETE(Waher.Networking.CoAP.CoapMessage Request,
            Waher.Networking.CoAP.CoapResponse Response) => Delete(Request, Response);

        public new Waher.Networking.CoAP.ICoapGetMethod GetMethod => this;
        public new Waher.Networking.CoAP.ICoapPutMethod PutMethod => this;
        public new Waher.Networking.CoAP.ICoapPostMethod PostMethod => this;
        public new Waher.Networking.CoAP.ICoapFetchMethod FetchMethod => this;
        public new Waher.Networking.CoAP.ICoapPatchMethod PatchMethod => this;
        public new Waher.Networking.CoAP.ICoapDeleteMethod DeleteMethod => this;

        private readonly CoAPMethod Get;
        private readonly CoAPMethod Put;
        private readonly CoAPMethod Post;
        private readonly CoAPMethod Fetch;
        private readonly CoAPMethod Patch;
        private readonly CoAPMethod Delete;

        public bool AllowsGET => Get != null;
        public bool AllowsPUT => Put != null;
        public bool AllowsPOST => Post != null;
        public bool AllowsFETCH => Fetch != null;
        public bool AllowsPATCH => Path != null;
        public bool AllowsDELETE => Delete != null;
    }
}
