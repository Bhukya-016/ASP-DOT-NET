using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.Models.DTO
{
    public class UpdateRegionRequestDto
    {
        [Required]
        [MinLength(3, ErrorMessage = "code has to be minimum of 3 charachters")]

        [MaxLength(3, ErrorMessage = "code has to be max of 3 characters")]
       
        public string Code { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "code has to be max of 100 characters")]
        public string Name { get; set; }
        public string? RegionImageUrl { get; set; }
    }
}
