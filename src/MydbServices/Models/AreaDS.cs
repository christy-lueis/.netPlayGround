using MydbServices.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MydbServices.Models
{
    public class Circle: IArea
    {
        [Key]
        public int pk_ID { get; set; }
        public double radius {  get; set; }
        public double Perimeter {  get; set; }
        public double Area() {
         
            return Math.PI * radius;

            
        }
    }

    public class Square : IArea
    {
        [Key]
        public int pk_ID { get; set; }

        public double length { get; set; }
        public double Area()
        {
            return length * length;
        }
    }

    public class Rectangle : IArea
    {
        [Key]
        public int pk_ID { get; set; }

        public double length { get; set; }
        public double breadth { get; set; }
        public double Area()
        {
          
            return length * breadth;
        }
    }

  
}
