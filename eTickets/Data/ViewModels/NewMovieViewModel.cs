using eTickets.Data.Enum;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Data.ViewModels
{
    public class NewMovieViewModel
    {
        public int Id { get; set; }
        [Display(Name ="Movie Name")]
        [Required(ErrorMessage = "Movie name is required ")]
        public string Name { get; set; }

        [Display(Name = "Movie Description")]
        [Required(ErrorMessage = "Movie Description is required ")]
        public string Description { get; set; }

        [Display(Name = "Price in $")]
        [Required(ErrorMessage = "Movie Price is required ")]
        public double Price { get; set; }


        [Display(Name = "Movie Poster URL")]
        [Required(ErrorMessage = "Movie Poster is required ")]
        public string ImageURL { get; set; }

        [Display(Name = "Start Date")]
        [Required(ErrorMessage = "Start Date is required ")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        [Required(ErrorMessage = "End Date is required ")]
        public DateTime EndDate { get; set; }


        [Display(Name = "Select a Movie Category")]
        [Required(ErrorMessage = "Movie Category is required ")]
        public MovieCategory MovieCategory { get; set; }

        //RelationShips
        [Display(Name = "Select actor(s) ")]
        [Required(ErrorMessage = "Movie actor(s) is/are required ")]
        public List<int> ActorIds { get; set; }

        //Cinema

        [Display(Name = "Select a cinema ")]
        [Required(ErrorMessage = "Movie Cinema is required ")]
        public int CinemaId { get; set; }

        //Producer

        [Display(Name = "Select a Producer ")]
        [Required(ErrorMessage = "Movie Producer is required ")]
        public int ProducerId { get; set; }
       

    }
}
