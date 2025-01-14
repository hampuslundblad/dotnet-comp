using System.ComponentModel.DataAnnotations;

namespace DotnetComp.Models.Requests
{
    public class CreatePlayerRequest
    {
        [Required]
        [MinLength(3), MaxLength(100)]
        public required string PlayerName { get; set; }
    }
}
