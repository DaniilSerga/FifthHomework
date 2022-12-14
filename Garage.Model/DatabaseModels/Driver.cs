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

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public Car? Car { get; set; } = new();
    }
}
