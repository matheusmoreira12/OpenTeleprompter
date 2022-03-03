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
            var fieldsAndProps = type.GetMembers(BindingFlags.Instance |
                BindingFlags.GetProperty | BindingFlags.GetField);
            foreach (var fieldOrProp in fieldsAndProps)
            {
                bool isMethodAttrDefined = Attribute.IsDefined(fieldOrProp,
                    typeof(Annotation.CoAPMethodAttribute));
                if (isMethodAttrDefined)
                {
                    CoAPMethod method = null;
                    if (fieldOrProp is FieldInfo field)
                    {
                        if (field.FieldType == typeof(CoAPResource))
                            method = (CoAPMethod)field.GetValue(this);
                    }
                    else if (fieldOrProp is PropertyInfo property)
                    {
                        if (property.PropertyType == typeof(CoAPResource))
                            method = (CoAPMethod)property.GetValue(this);
                    }

                    if (method != null)
                    {
                        var methodAttr = (Annotation.CoAPMethodAttribute)
                            fieldOrProp.GetCustomAttribute(typeof(Annotation.CoAPMethodAttribute));
                        switch (methodAttr.Type)
                        {
                            case Annotation.CoAPMethodType.Get:
                                GetMethod = method;
                                break;
                            case Annotation.CoAPMethodType.Put:
                                PutMethod = method;
                                break;
                            case Annotation.CoAPMethodType.Post:
                                PostMethod = method;
                                break;
                            case Annotation.CoAPMethodType.Fetch:
                                FetchMethod = method;
                                break;
                            case Annotation.CoAPMethodType.Patch:
                                PatchMethod = method;
                                break;
                            case Annotation.CoAPMethodType.Delete:
                                DeleteMethod = method;
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
