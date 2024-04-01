using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviatoCore.Domain.Entities
{
    public class Repair
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public Service? Service { get; set; }
        public int RepairTypeId { get; set; }
        public RepairType? RepairType { get; set; }
        public ICollection<RepairDependency>? RepairADependencies { get; set; }
        public ICollection<RepairDependency>? RepairBDependencies { get; set; }
        public ICollection<FlightRepair>? FlightRepairs { get; set; }
    } 

    public class RepairType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Repair>? Repairs { get; set; } 
    }
}
