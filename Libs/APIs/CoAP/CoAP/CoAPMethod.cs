using System.Threading.Tasks;

namespace OpenTeleprompter.APIs.CoAP
{
    public delegate Task CoAPMethod(Waher.Networking.CoAP.CoapMessage request,
        Waher.Networking.CoAP.CoapResponse response);
}
