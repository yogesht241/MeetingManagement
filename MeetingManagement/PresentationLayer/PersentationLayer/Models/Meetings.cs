using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersentationLayer.Models
{
    public class Meetings
    {
        public int MeetingID { get; set; }
        public string Subject { get; set; }
        public string Attendees { get; set; }

        public string Agenda { get; set; }
        public DateTime DateTime { get; set; }
    }
}