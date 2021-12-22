using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.Text;

namespace EFLib.Models
{
    abstract class BaseClass
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
