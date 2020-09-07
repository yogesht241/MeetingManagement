﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.DataLayer.Entities
{
    [Table("AttendeeInfo")]
    public partial class AttendeeInfo
    {
        [Key]
        public int AttendeeID { get; set; }
        public string Name { get; set; }

    }
   
}
