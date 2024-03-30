using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviatoCore.Domain.Entities
{
    public class Service
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int FacilityId { get; set; }
        public Facility? Facility { get; set; }
        public ICollection<FlightService>? FlightServices { get; set; }
        public ICollection<ClientServices>? ClientServices{ get; set; }
        public ICollection<Review>? Reviews { get; set; }
        public ICollection<Repair>? Repairs { get; set; }
        public bool IsDeleted { get; set; }

    }
}