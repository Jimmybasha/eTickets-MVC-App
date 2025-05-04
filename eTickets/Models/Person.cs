﻿using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    abstract public class Person
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="Full name")]
        public string FullName { get; set; }

        [Display(Name = "Profile Picture")]
        public string ProfilePictureUrl { get; set; }

        [Display(Name ="Biography")]
        public string Bio { get; set; }


    }
}
