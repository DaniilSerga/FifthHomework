using System.ComponentModel.DataAnnotations;

namespace Garage.Model.ViewModels
{
    public class DriverEditViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }
    }
}
