using System.ComponentModel.DataAnnotations;

namespace Garage.Model.DTOModels
{
    public class RegisterDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
