using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using OpenTeleprompter.APIs.CoAP.InterfaceLayer;
using Waher.Networking.CoAP;

namespace OpenTeleprompter.APIs.CoAP
{
    public abstract class CoAPResource
    {
        public CoAPResource(Uri path)
        {
            Path = path;
            AssignMethods();
        }

        private void AssignMethods()
        {
            var type = GetType();
            var methods = type.GetMethods();
            foreach (var method in methods)
            {
                bool isMethodAttrDefined = Attribute.IsDefined(method,
                    typeof(Annotation.CoAPMethodAttribute));
                if (isMethodAttrDefined)
                {
                    if (method != null)
                    {
                        var methodAttr = (Annotation.CoAPMethodAttribute)
                            method.GetCustomAttribute(typeof(Annotation.CoAPMethodAttribute));
                        var methodDelegate = (CoAPMethod)method.CreateDelegate(typeof(CoAPMethod));
                        switch (methodAttr.Type)
                        {
                            case Annotation.CoAPMethodType.Get:
                                GetMethod = methodDelegate;
                                break;
                            case Annotation.CoAPMethodType.Put:
                                PutMethod = methodDelegate;
                                break;
                            case Annotation.CoAPMethodType.Post:
                                PostMethod = methodDelegate;
                                break;
                            case Annotation.CoAPMethodType.Fetch:
                                FetchMethod = methodDelegate;
                                break;
                            case Annotation.CoAPMethodType.Patch:
                                PatchMethod = methodDelegate;
                                break;
                            case Annotation.CoAPMethodType.Delete:
                                DeleteMethod = methodDelegate;
                                break;
                        }
                    }
                }
            }
        }

        public readonly Uri Path;
        public CoAPMethod GetMethod { get; private set; }
        public CoAPMethod PutMethod { get; private set; }
        public CoAPMethod PostMethod { get; private set; }
        public CoAPMethod FetchMethod { get; private set; }
        public CoAPMethod PatchMethod { get; private set; }
        public CoAPMethod DeleteMethod { get; private set; }
    }
}
