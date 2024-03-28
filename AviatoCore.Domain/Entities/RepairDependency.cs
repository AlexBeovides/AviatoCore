using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviatoCore.Domain.Entities
{
    public class RepairDependency
    {
        public int PlaneConditionId { get; set; }
        public PlaneCondition PlaneCondition { get; set; }
        public int RepairAId { get; set; }
        public Repair RepairA { get ; set; }
        public int RepairBId { get; set; }
        public Repair RepairB { get; set; }
    }
    public class PlaneCondition
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
