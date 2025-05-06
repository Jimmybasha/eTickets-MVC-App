using eTickets.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Producer : Person 
    {
  
        List<Movie> Movies { get; set; }

    }
}
