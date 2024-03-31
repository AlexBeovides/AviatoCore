using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviatoCore.Application.DTOs
{
    public class ClientDto
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Country { get; set; }
        public int ClientTypeId { get; set; }
        public bool IsDeleted { get; set; }
        public string Password { get; set; }
    }
}
