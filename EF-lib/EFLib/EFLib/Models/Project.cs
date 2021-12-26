using EFLib.Models.Catalogs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EFLib.Models
{
    [Table("Project")]
    public class Project: BaseClass
    {
        [Key]
        [Required]
       public string Сipher { get; set; }
        [Required]
       public BaseCatalog Performer { get; set; }

        public virtual ICollection<ObjectDesign> Objects { get; set; }
    }
}
