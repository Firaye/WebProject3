using System;
using System.Collections.Generic;

namespace WebProject3.Models
{
    public partial class Divorcetbl
    {
        public int Did { get; set; }
        public DateTime DateofDivorce { get; set; }
        public int DcirtificateNumber { get; set; }
        public string HusbandFullName { get; set; }
        public string WifeFullName { get; set; }
        public int WifeAge { get; set; }
        public string RequesterofDinvorce { get; set; }
        public DateTime IssueDate { get; set; }
        public int Cid { get; set; }

        public Custometbl C { get; set; }
    }
}
