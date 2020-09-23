using System;
using System.Collections.Generic;

namespace WebProject3.Models
{
    public partial class Deathtbl
    {
        public int DrefNum { get; set; }
        public DateTime DateofDeath { get; set; }
        public string CaseofDeath { get; set; }
        public string Region { get; set; }
        public string Zone { get; set; }
        public string Woreda { get; set; }
        public string Wittness { get; set; }
        public string Reltionofwittness { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }
        public DateTime IssueDate { get; set; }
        public int Cid { get; set; }

        public Custometbl C { get; set; }
    }
}
