using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace CRUD.DataLayer.Entities
{
    [Table("MeetingInfo")]
    public partial   class MeetingInfo
    {
        [Key]
        public int MeetingID { get; set; }
        [StringLength(50)]
        public string Subject { get; set; }
        [StringLength(50)]
        public string Attendees { get; set; }
        [StringLength(50)]
        public string Agenda { get; set; }
        public DateTime DateTime { get; set; }

    }
}
