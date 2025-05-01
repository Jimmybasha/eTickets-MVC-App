using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    abstract public class Person
    {
        [Key]
        public int Id { get; set; }

        public string FullName { get; set; }

        public string ProfilePictureUrl { get; set; }

        public string Bio { get; set; }


    }
}
