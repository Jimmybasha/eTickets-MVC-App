using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    abstract public class Person
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="Full name")]
        [Required(ErrorMessage = "FullName is required")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Full name must be between 5 and 50 Characters")]
        public string FullName { get; set; }

        [Display(Name = "Profile Picture")]
        [Required(ErrorMessage = "ProfilePictureUrl is required")]
        public string ProfilePictureUrl { get; set; }

        [Display(Name ="Biography")]
        [Required(ErrorMessage ="Biography is required")]
        public string Bio { get; set; }


    }
}
