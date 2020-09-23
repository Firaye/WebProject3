using System;
using System.Collections.Generic;

namespace WebProject3.Models
{
    public partial class Adoptiontbl
    {
        public int AdoptId { get; set; }
        public string ChildFullName { get; set; }
        public string AdoptFullName { get; set; }
        public string CitizenshipofAdopter { get; set; }
        public int Ageofchild { get; set; }
        public int AdopterphoneNumber { get; set; }
        public string ReasonforAdoption { get; set; }
        public string Sexofchild { get; set; }
        public DateTime? IssueDate { get; set; }
        public int Cid { get; set; }

        public Custometbl C { get; set; }
    }
}
