using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MydbServices.Models
{
    public class VehicleDS
    {
        [Key]
        public int pk_ID { get; set; }
        public string item { get; set; }
        public double price { get; set; }
    }
}
