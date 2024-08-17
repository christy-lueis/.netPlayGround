using Log.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log.Models
{
    public class LoggingDS 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int pk_Id {  get; set; }
        public string Processtype {  get; set; }
        public string ProcessName {  get; set; }
        public DateTime Time {  get; set; }
        public DateTime CreatedTime {  get; set; }=DateTime.Now;
        
     
    }
}
