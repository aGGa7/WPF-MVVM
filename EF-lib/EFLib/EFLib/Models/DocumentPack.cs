using EFLib.Models.Catalogs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EFLib.Models
{
    public class DocumentPack
    {
        [Required]
        public  int Number { get; set; }
        [Required]
        public Mark Mark { get; set; }
        public string MarkName { get => Mark.Name; set => _ = value; }

         public  Guid ObjectDesignId { get; set; }
        public ObjectDesign Object { get; set; }

        public ICollection<Document> Documents { get; set; }
    }
}
