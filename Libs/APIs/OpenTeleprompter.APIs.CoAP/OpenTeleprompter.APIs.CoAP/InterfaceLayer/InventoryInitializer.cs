using System;
namespace OpenTeleprompter.APIs.CoAP.InterfaceLayer
{
    public static class InventoryInitializer
    {
        public static void Initialize()
        {
            if (!Waher.Runtime.Inventory.Types.IsInitialized)
                Waher.Runtime.Inventory.Types.Initialize();
        }
    }
}
