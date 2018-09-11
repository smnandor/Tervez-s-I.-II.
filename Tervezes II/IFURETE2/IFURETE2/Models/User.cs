using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace IFURETE2.Models
{
    public class User
    {
        public int ID { get; set; }
        [StringLength(25, MinimumLength = 6)]
        public string name { get; set; }
        [StringLength(25, MinimumLength = 6)]
        public string username { get; set; }
        public int phone_number { get; set; }
        [StringLength(60, MinimumLength = 3)]
        public string e_mail { get; set; }
    }
}
