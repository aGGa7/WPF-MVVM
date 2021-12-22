using EFLib.Models.Catalogs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EFLib.Models
{
    class DocumentPack:BaseClass
    {
        public  int Number { get; set; }
        public Catalog Mark { get; set; } 
        [Key]
        [ForeignKey("ObjectDesign")]
         public new Guid Id { get; set; }
        public ObjectDesign Object { get; set; }

        public ICollection<Document> Documents { get; set; }
    }
}
