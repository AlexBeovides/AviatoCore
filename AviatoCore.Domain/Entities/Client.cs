using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviatoCore.Domain.Entities
{
    public class Client
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Nationality { get; set; }

        [Required]
        public string ClientType { get; set; }
    }
}
