using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IFURETE4.Models
{
    public class Role
    {
        public int ID { get; set; }
        public string name_of_role { get; set; }
        public int material { get; set; }
        public int sites { get; set; }
        public int users { get; set; }
        public int recipient_ui { get; set; }
        public int supplier_limit { get; set; }
        public int booking_ui { get; set; }
        public int report_ui { get; set; }
        public int EAKER_ui { get; set; }
    }
}
