using System;
using System.Collections.Generic;

namespace WebProject3.Models
{
    public partial class Birthtbl
    {
        public int Cnum { get; set; }
        public DateTime Dob { get; set; }
        public string Mfullname { get; set; }
        public string Region { get; set; }
        public string Woreda { get; set; }
        public string Sex { get; set; }
        public DateTime DateofIssue { get; set; }
        public int Cid { get; set; }

        public Custometbl C { get; set; }
    }
}
