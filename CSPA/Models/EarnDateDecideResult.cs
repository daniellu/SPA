using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSPA.Models
{
    public class EarnDateDecideResult
    {
        public string Code { get; set; }
        public string Level { get; set; }
        public DateTime? EarnReleaseDate { get; set; }
        public bool IsSuccess { get; set; }
        public string Comments { get; set; }
    }
}