using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviatoCore.Domain.Entities
{
    public class Review
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime ReviewedAt { get; set; }
        public string ClientId { get; set; }
        public Client Client { get; set; }
        public int ServiceId { get; set; }
        public Service Service { get; set; }
    }
}
