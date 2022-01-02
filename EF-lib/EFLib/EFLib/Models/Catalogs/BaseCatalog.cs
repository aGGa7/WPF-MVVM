using System;
using System.Collections.Generic;
using System.Text;

namespace EFLib.Models.Catalogs
{
    public class BaseCatalog:BaseClass
    {
        public string FullName { get; set; }
    }
    public class Performer : BaseCatalog
    {
        public Project Project { get; set; }
    }
    public class Mark : BaseCatalog 
    {
        public DocumentPack DocumentPack { get; set; }
    }
    public class TypeDoc : BaseCatalog 
    {
        public Document Document { get; set; }
    }
}
