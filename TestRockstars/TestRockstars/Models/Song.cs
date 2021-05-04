using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestRockstars.Models
{
    public class Song
    {
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a positive number")]
        public int Id { get; set; }

        [Required]
        [MaxLength(255, ErrorMessage = "Name must be 255 characters or less"), MinLength(1)]
        public string Name { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a positive number")]
        public int Year { get; set; }

        [Required]
        [MaxLength(255, ErrorMessage = "Artist must be 255 characters or less"), MinLength(1)]
        public string Artist { get; set; }

        [Required]
        [MaxLength(255, ErrorMessage = "Shortname must be 255 characters or less"), MinLength(1)]
        public string Shortname { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Please enter a positive number")]
        public int? Bpm { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a positive number")]
        public int Duration { get; set; }

        [Required]
        [MaxLength(255, ErrorMessage = "Genre must be 255 characters or less"), MinLength(1)]
        public string Genre { get; set; }

        [MaxLength(255, ErrorMessage = "SpotifyId must be 255 characters or less"), MinLength(1)]
        public string SpotifyId { get; set; }

        [MaxLength(255, ErrorMessage = "Album must be 255 characters or less"), MinLength(1)]
        public string Album { get; set; }
    }
}