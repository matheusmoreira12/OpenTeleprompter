using System;
using System.Collections.Generic;

namespace OpenTeleprompter.Data.Hierarchy
{
    internal static class HierarchyManager
    {
        private const string PARENT_ALREADY_DEFINED_ERROR_MESSAGE =
            "A parent has already been defined for the specified object.";

        private const string PARENT_NOT_DEFINED_ERROR_MESSAGE =
            "No parent has been defined for the specified object.";

        private static Dictionary<object, object> ChildrenAndParents =
            new Dictionary<object, object> { };

        public static void SetParent(object obj, object parent)
        {
            if (ChildrenAndParents.ContainsKey(obj))
                throw new InvalidOperationException(PARENT_ALREADY_DEFINED_ERROR_MESSAGE);
            ChildrenAndParents[obj] = parent;
        }

        public static object GetParent(object obj)
        {
            if (ChildrenAndParents.ContainsKey(obj))
                return ChildrenAndParents[obj];
            throw new InvalidOperationException(PARENT_NOT_DEFINED_ERROR_MESSAGE);
        }

        public static void UnsetParent(object obj)
        {
            if (ChildrenAndParents.ContainsKey(obj))
            {
                ChildrenAndParents.Remove(obj);
                return;
            }
            throw new InvalidOperationException(PARENT_NOT_DEFINED_ERROR_MESSAGE);
        }
    }
}
