using System.Collections.Specialized;

namespace UnfolderForms
{
    public class FolderCollection
    {
        public FolderCollection()
        {
            Collection = new StringCollection();
        }

        private StringCollection Collection { get; set; }

        public void AddToCollection(string text)
        {
            Collection.Add(text);
        }

        public void ClearCollection()
        {
            Collection.Clear();
        }
    }
}