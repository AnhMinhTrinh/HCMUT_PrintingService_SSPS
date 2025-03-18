﻿using System.ComponentModel.DataAnnotations;

namespace Printing_Service.Models
{
    public class Student
    {
        [Required(ErrorMessage = "ID is required.")]
        public string ID {get; set;}
        public string name { get; set; }
        public int Remain_page { get; set; }
        public string SPSO_ID { get; set; }
    
    }
}
