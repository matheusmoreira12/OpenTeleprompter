using System;
using OpenTeleprompter.Data.Hierarchy;

namespace OpenTeleprompter.Data
{
    public sealed class Page
    {
        public Page(Text text)
        {
            Text = text;

            HierarchyManager.SetParent(Text, this);
        }

        ~Page()
        {
            HierarchyManager.UnsetParent(Text);
        }

        public readonly Text Text;

        public Document ParentDocument => (Document)HierarchyManager.GetParent(this);
    }
}
