﻿using System.ComponentModel.DataAnnotations;

namespace Demo.Areas.Admin.Models
{
    public class AddAuthorModel
    {
        [MaxLength(100)]
        public string Name { get; set;  }
        [Required]
        public string Biography { get; set; }
        [Required]
        public double Rating { get; set; }
    }
}
