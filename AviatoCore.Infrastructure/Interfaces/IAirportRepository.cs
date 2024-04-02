using AviatoCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviatoCore.Infrastructure.Interfaces
{
    public interface IAirportRepository
    {
        Task<Airport> GetAirportAsync(int id);
        Task<IEnumerable<Airport>> GetAllAirportsAsync();
        Task AddAirportAsync(Airport airport);
        Task UpdateAirportAsync(Airport airport);
        Task DeleteAirportAsync(int id);
    }
}
