using AviatoCore.Application.Interfaces;
using AviatoCore.Domain.Entities; 
using AviatoCore.Infrastructure;
using AviatoCore.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviatoCore.Application.Services
{
    public class AirportService : IAirportService
    {
        private readonly IAirportRepository _airportRepository;

        public AirportService(IAirportRepository airportRepository)
        {
            _airportRepository = airportRepository;
        }

        public async Task<Airport> GetAirportAsync(int id)
        {
            return await _airportRepository.GetAirportAsync(id);
        }

        public async Task<IEnumerable<Airport>> GetAllAirportsAsync()
        {
            return await _airportRepository.GetAllAirportsAsync();
        }

        public async Task AddAirportAsync(Airport airport)
        {
            await _airportRepository.AddAirportAsync(airport);
        }

        public async Task UpdateAirportAsync(Airport airport)
        {
            await _airportRepository.UpdateAirportAsync(airport);
        }

        public async Task DeleteAirportAsync(int id)
        {
            await _airportRepository.DeleteAirportAsync(id);
        }
    }
}
