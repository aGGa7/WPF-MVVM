using EFLib.Models.Catalogs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EFLib.Models
{
    public class Document:BaseClass
    {
        [Required]
        public TypeDoc TypeDoc { get; set; }
        [Required]
        public int Number { get; set; }

        public Guid DocumentPackId { get; set; }
        public DocumentPack Pack { get; set; }
    }
}
