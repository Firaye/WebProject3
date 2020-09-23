using System;
using System.Collections.Generic;

namespace WebProject3.Models
{
    public partial class Marriagetbl
    {
        public int Mnum { get; set; }
        public DateTime DateofMarriage { get; set; }
        public string HusbandFullname { get; set; }
        public string Wifefullname { get; set; }
        public string Wittness1 { get; set; }
        public string Wittness2 { get; set; }
        public int WifeAge { get; set; }
        public int HusbandAge { get; set; }
        public string Region { get; set; }
        public string Zone { get; set; }
        public DateTime? IssueDate { get; set; }
        public int Cid { get; set; }

        public Custometbl C { get; set; }
    }
}
