using System;
using OpenTeleprompter.Data.Hierarchy;

namespace OpenTeleprompter.Data
{
    public class Document
    {
        public Document(Page[] pages, Size pageSize, PageStyle pageStyle)
        {
            Pages = pages ?? throw new ArgumentNullException(nameof(pages));
            PageSize = pageSize;
            PageStyle = pageStyle;

            SetPagesParent();
        }

        private void SetPagesParent()
        {
            foreach (var page in Pages)
                HierarchyManager.SetParent(page, this);
        }

        ~Document()
        {
            UnsetPagesParent();
        }

        private void UnsetPagesParent()
        {
            foreach (var page in Pages)
                HierarchyManager.UnsetParent(page);
        }

        public readonly Page[] Pages;
        public readonly Size PageSize;
        public readonly PageStyle PageStyle;
    }
}
