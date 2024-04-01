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
        [Key]
        public string ClientId { get; set; }
        public string UserId { get; set; } // Foreign key to User
        public string Country { get; set; }
        public int ClientTypeId { get; set; }
        public User? User { get; set; } // Navigation property
        public ClientType? ClientType { get; set; }
        public ICollection<Plane>? Planes { get; set; }
        public ICollection<ClientServices>? ClientServices { get; set; }
        public ICollection<Review>? Reviews { get; set; }
    }

    public class ClientType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Client>? Clients { get; set; }
    }
}
