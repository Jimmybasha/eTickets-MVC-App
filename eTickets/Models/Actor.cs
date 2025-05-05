using eTickets.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Actor : Person,IEntityBase
    {

        public List<Actor_Movie>? MovieActors { get; set; } = new List<Actor_Movie>();


    }
}
