using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IFURETE4.Models
{
    public class Delivery
    {
        public int ID { get; set; }
        public int actual_amount { get; set; }
        public bool delivered { get; set; }
        public bool weighed { get; set; }
        public bool denied { get; set; }

    }
}
