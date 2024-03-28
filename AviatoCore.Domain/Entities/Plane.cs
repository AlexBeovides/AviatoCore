using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviatoCore.Domain.Entities
{
    public class Plane
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Classification { get; set; }
        public double CargoCapacity { get; set; }            // position latitude
        public int CrewCount { get; set; }
        public int PassengerCapacity { get; set; }
        public string OwnerId { get; set; }
        public Client Owner { get; set; }
    }
}