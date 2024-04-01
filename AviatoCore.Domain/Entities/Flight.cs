using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviatoCore.Domain.Entities
{
    public class Flight
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime DepartureTime { get; set; }
        public int AirportId { get; set; }
        public Airport? Airport { get; set; }
        public int PlaneId { get; set; }
        public Plane? Plane { get; set; }
        public int OwnerRoleId { get; set; }
        public OwnerRole? OwnerRole { get; set; }
        public ICollection<FlightRepair>? FlightRepairs { get; set; }
        public bool NeedsCheck { get; set; }
        public int PlaneConditionId { get; set; }
        public PlaneCondition? PlaneCondition { get; set; }
    }

    public class OwnerRole
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Flight>? Flights { get; set; }
    }
    public class PlaneCondition
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Flight>? Flights { get; set; }
        public ICollection<RepairDependency>? RepairDependencies { get; set; }
    }
}
