using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Task
{
    public class DocumentNode
    {
        public string Name {  get; set; }
        public ObservableCollection<Document> Documents { get; set; } = new ObservableCollection<Document>();
    }
}
