using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication_Kaido15.Models
{
    public class Student
    {
        public int id { get; set; }

        [Required]
        public string name { get; set; }

        public string address { get; set; }

        [Required]
        public int age { get; set; }

        [Required]
        public string standard { get; set; }

        [Required]
        [RegularExpression(@"^\d+\.\d{0,2}$", ErrorMessage = "Invalid should be like 79.76")]
        public decimal percent { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime addedOn { get; set; }

        [Required]
        public bool status { get; set; }
    }
}