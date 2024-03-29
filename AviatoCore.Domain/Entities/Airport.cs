using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviatoCore.Domain.Entities
{
    public class Airport
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double Latitude { get; set; }            // position latitude
        public double Longitude { get; set; }           // position latitude                                              
        public ICollection<Facility>? Facilities { get; set; }
        public ICollection<Worker>? Workers { get; set; }
        public ICollection<Flight>? Flights { get; set; }
        public bool IsDeleted { get; set; }
    }
}
