using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace OpenTeleprompter.APIs.CoAP
{
    public abstract class CoAPServer
    {
        public CoAPServer(params int[] ports)
        {
            // TODO: Initialize server

            Resources = GetResources().ToArray();
            RegisterResources();
        }

        private void RegisterResources()
        {
            foreach (var resource in Resources)
            {
                //TODO : Register each resource
            }
        }

        private IEnumerable<CoAPResource> GetResources()
        {
            var type = GetType();
            var fieldsAndProps = type.GetMembers(BindingFlags.Instance |
                BindingFlags.GetProperty | BindingFlags.GetField);
            foreach (var fieldOrProp in fieldsAndProps)
            {
                fieldOrProp.GetCustomAttribute(typeof(Annotation.CoAPMethodAttribute));
                if (fieldOrProp is FieldInfo)
                {
                    var field = (FieldInfo)fieldOrProp;
                    if (field.FieldType == typeof(CoAPResource))
                        yield return (CoAPResource)field.GetValue(this);
                }
                else if (fieldOrProp is PropertyInfo)
                {
                    var property = (PropertyInfo)fieldOrProp;
                    if (property.PropertyType == typeof(CoAPResource))
                        yield return (CoAPResource)property.GetValue(this);
                }
            }
        }

        private readonly Waher.Networking.CoAP.CoapEndpoint EndPoint;
        public readonly CoAPResource[] Resources;
    }
}
