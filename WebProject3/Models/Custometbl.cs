using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebProject3.Models
{
    public partial class Custometbl
    {
        public Custometbl()
        {
            Adoptiontbl = new HashSet<Adoptiontbl>();
            Divorcetbl = new HashSet<Divorcetbl>();
            Marriagetbl = new HashSet<Marriagetbl>();
        }



        [Key]
        [Required(ErrorMessage = "Please enter Customer ID")]
        public int Cid { get; set; }
        [Required(ErrorMessage = "Please enter first name")]
        public string Fname { get; set; }
        [Required(ErrorMessage = "Please enter last name")]
        public string Lname { get; set; }
        public string Country { get; set; }
        


        public Birthtbl Birthtbl { get; set; }
        public Deathtbl Deathtbl { get; set; }
        public ICollection<Adoptiontbl> Adoptiontbl { get; set; }
        public ICollection<Divorcetbl> Divorcetbl { get; set; }
        public ICollection<Marriagetbl> Marriagetbl { get; set; }
    }
}
