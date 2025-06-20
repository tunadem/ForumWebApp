﻿using System.ComponentModel.DataAnnotations;

namespace ForumWebApp.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
    }
}
