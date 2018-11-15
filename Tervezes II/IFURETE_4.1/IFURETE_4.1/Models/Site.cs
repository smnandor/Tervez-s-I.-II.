using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IFURETE4.Models
{
    public class Site
    {
        public int ID { get; set; }        
        public string Name { get; set; }
        public string Address { get; set; }
        public string NameOfContact { get; set; }
        public string EmailAddressOfContact { get; set; }
        public string PhonenumberOfContact { get; set; }
        public string OpenFrom { get; set; }
        public string OpenTo { get; set; }
        public string NumberOfTrucks { get; set; }

    }
}
