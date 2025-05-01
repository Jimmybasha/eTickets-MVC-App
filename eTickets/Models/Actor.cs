using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Actor : Person
    {

        public List<Actor_Movie> MovieActors { get; set; }


    }
}
