using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestRockstars.Models
{
    public class Artist
    {
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a positive number")]
        public int Id { get; set; }
        [Required]
        [MaxLength(255, ErrorMessage = "Name must be 255 characters or less"), MinLength(1)]
        public string Name { get; set; }
    }
}