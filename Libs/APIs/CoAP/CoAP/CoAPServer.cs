using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace OpenTeleprompter.APIs.CoAP
{
    public abstract class CoAPServer
    {
        public CoAPServer(params int[] ports)
        {
            Ports = ports;

            AssignResources();
            InitializeEndpoint();
        }

        private void AssignResources()
        {
            Resources = GetResources().ToArray();
        }

        private IEnumerable<CoAPResource> GetResources()
        {
            var type = GetType();
            var fieldsAndProps = type.GetMembers(BindingFlags.Instance |
                BindingFlags.GetProperty | BindingFlags.GetField);
            foreach (var fieldOrProp in fieldsAndProps)
            {
                var attr = (Annotation.CoAPResourceAttribute)fieldOrProp
                    .GetCustomAttribute(typeof(Annotation.CoAPResourceAttribute));
                if (attr != null)
                {
                    if (fieldOrProp is FieldInfo field)
                    {
                        if (field.FieldType == typeof(CoAPResource))
                            yield return (CoAPResource)field.GetValue(this);
                    }
                    else if (fieldOrProp is PropertyInfo property)
                    {
                        if (property.PropertyType == typeof(CoAPResource))
                            yield return (CoAPResource)property.GetValue(this);
                    }
                }
            }
        }

        private void InitializeEndpoint()
        {
            EndPoint = new Waher.Networking.CoAP.CoapEndpoint(Ports, null, null, null, false, false);

            foreach (var resource in Resources)
            {
                var ilResource = new InterfaceLayer.CoAPResource(resource.Path.ToString(),
                    resource.GetMethod, resource.PutMethod, resource.PostMethod,
                    resource.FetchMethod, resource.PatchMethod, resource.DeleteMethod);
                EndPoint.Register(ilResource);
            }
        }

        private readonly int[] Ports;

        protected Waher.Networking.CoAP.CoapEndpoint EndPoint { get; private set; }

        public CoAPResource[] Resources { get; private set; }
    }
}
