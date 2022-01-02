using EFLib.Models.Catalogs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EFLib.Models
{
    [Table("Project")]
    public partial class Project: BaseClass
    {
        [Required]
       public string Сipher { get; set; }
        [Required]
       public Performer Performer { get; set; }

        public virtual ICollection<ObjectDesign> Objects { get; set; }

        public Project ()
        {
            Сipher = string.Empty;
            Performer = new Performer();
        }
        public Project(int num)
        {
            Name = "Новый проект_"+ num;
            DateCreate = new DateTime().ToUniversalTime();
            Сipher = "Шифр_" + num;
            
        }
    }
}
