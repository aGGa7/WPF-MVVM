using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.Text;

namespace EFLib.Models
{
    public abstract class BaseClass
    {
        //используется аннотация данных, также для этого может использоваться FluentAPI, но используется аннотация для более естественного описания полей (нет необходимости смотерть в OnModelCreating чтобы видеть какие св-ва заданы)
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime DateCreate { get; set; }
        [Required]
        public DateTime DateChange { get; set; }
    }
}
