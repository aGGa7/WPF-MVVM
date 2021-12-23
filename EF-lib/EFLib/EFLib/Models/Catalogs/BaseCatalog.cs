using System;
using System.Collections.Generic;
using System.Text;

namespace EFLib.Models.Catalogs
{
    class BaseCatalog:BaseClass
    {
        public string FullName { get; set; }
    }
    class Performer : BaseCatalog { }
    class Mark : BaseCatalog { }
    class TypeDoc : BaseCatalog { }
}
