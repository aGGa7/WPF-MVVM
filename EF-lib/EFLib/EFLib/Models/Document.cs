using EFLib.Models.Catalogs;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFLib.Models
{
    class Document:BaseClass
    {
        public Catalog TypeDoc { get; set; }
        public int Number { get; set; }

        public Guid DocumentPackId { get; set; }
        public DocumentPack Pack { get; set; }
    }
}
