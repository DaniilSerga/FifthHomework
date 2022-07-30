using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Garage.Model.DatabaseModels
{
    [Table("Drivers")]
    public class Driver
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = "";

        public int Age { get; set; }

        public List<Car> Cars { get; set; } = new();
    }
}
