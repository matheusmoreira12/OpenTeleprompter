using System;
using System.Collections.Generic;
using System.Linq;
using OpenTeleprompter.Data.Hierarchy;

namespace OpenTeleprompter.Data
{
    public sealed class Text
    {
        public readonly string String;
        public readonly TextStyle Style;

        public Text(string content, TextStyle style)
        {
            String = content;
            Style = style;
        }

        public Page ParentPage => (Page)HierarchyManager.GetParent(this);
    }
}