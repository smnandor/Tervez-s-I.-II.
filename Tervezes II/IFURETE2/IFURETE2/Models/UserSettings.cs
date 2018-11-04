using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace IFURETE2.Models
{
    public class UserSettings
    {
        public int ID { get; set; }
        public string Role { get; set; }
        public bool IsBanned { get; set; }
        public DateTime BanDateFrom { get; set; }
        public DateTime BanDateTo { get; set; }
        public bool IsConfirmed { get; set; }

    }
}
