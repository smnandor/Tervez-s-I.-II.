using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace IFURETE2.Models
{
    public class Booking
    {
        public int ID { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime date { get; set; }
        public TimeSpan time_start { get; set; }
        public TimeSpan time_end { get; set; }
        public int weight { get; set; }
        public int number_of_trucks { get; set; }
    }
}
