using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Garage.Model.DatabaseModels
{
    [Table("Cars")]
    public class Car
    {
        [Key]
        public int Id { get; set; }

        public string Model { get; set; } = "";

        public int DriverId { get; set; }

        public Driver Driver { get; set; }
    }
}
