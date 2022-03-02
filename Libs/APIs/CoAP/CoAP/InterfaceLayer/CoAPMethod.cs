using System.Threading.Tasks;

namespace OpenTeleprompter.APIs.CoAP.InterfaceLayer
{
    internal delegate Task CoAPMethod(Waher.Networking.CoAP.CoapMessage request,
        Waher.Networking.CoAP.CoapResponse response);
}
