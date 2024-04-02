using AviatoCore.Domain.Entities;
using AviatoCore.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviatoCore.Application.Interfaces
{
    public interface IAirportService
    {
        Task<Airport> GetAirportAsync(int id);
        Task<IEnumerable<Airport>> GetAllAirportsAsync();
        Task AddAirportAsync(Airport airport);
        Task UpdateAirportAsync(Airport airport);
        Task DeleteAirportAsync(int id);
    }
}
