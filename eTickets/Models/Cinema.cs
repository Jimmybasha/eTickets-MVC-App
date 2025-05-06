﻿using eTickets.Data.Base;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Cinema : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Cinema Logo")]
        public string Logo { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        List<Movie> Movies { get; set; }    
    }
}
