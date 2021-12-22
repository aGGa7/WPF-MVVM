using EFLib.Models.Catalogs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EFLib.Models
{
    [Table("Project")]
    class Project: BaseClass
    {
        [Key]
       public string Сipher { get; set; }
       public Catalog Performer { get; set; }

        public virtual ICollection<ObjectDesign> Objects { get; set; }
    }
}
