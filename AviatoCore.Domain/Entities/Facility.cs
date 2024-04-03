using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviatoCore.Domain.Entities
{
    public class Facility
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id  { get; set; }
        public string Name  { get; set; }
        public string Description  { get; set; }
        public string Address { get; set; }
        public string ImgUrl { get; set; }
        public int AirportId { get; set; }
        public Airport? Airport { get; set; }
        public int FacilityTypeId { get; set; }
        public FacilityType? FacilityType { get; set; }
        public ICollection<Service>? Services { get; set; }
        public bool IsDeleted { get; set; }
    }
    public class FacilityType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Facility>? Facilities { get; set; }
    }
}
