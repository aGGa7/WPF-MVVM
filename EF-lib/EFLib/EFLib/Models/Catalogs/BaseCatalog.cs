using System;
using System.Collections.Generic;
using System.Text;

namespace EFLib.Models.Catalogs
{
    public class BaseCatalog:BaseClass
    {
        public string FullName { get; set; }
    }
    public class Performer : BaseCatalog { }
    public class Mark : BaseCatalog { }
    public class TypeDoc : BaseCatalog { }
}
