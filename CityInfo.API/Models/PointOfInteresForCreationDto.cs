using System.ComponentModel.DataAnnotations;

namespace CityInfo.API.Models
{
    public class PointOfInteresForCreationDto
    {
        [Required(ErrorMessage = "You need a name dumbass")]
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string? Description { get; set; }
    }
}
