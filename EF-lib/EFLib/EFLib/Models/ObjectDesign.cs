﻿using EFLib.Models.Catalogs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EFLib.Models
{
    class ObjectDesign:BaseClass
    {
        [Key]
        public string Code { get; set; }
        public Catalog Performer { get; set; }
        public Guid ParentId { get; set; }
        public Guid ProjectId { get; set; }
        public Project Project { get; set; }
        public DocumentPack DocumentPack { get; set; }
    }
}