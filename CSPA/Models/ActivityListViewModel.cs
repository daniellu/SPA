using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSPA.Models
{
    public class ActivityListViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string ActivityType { get; set; }
        public DateTime DateTime { get; set; }
        public int ElapseTimeSeconds { get; set; }
        public float Distance { get; set; }
    }
}