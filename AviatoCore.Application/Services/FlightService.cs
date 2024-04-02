using AviatoCore.Application.Interfaces;
using AviatoCore.Domain.Entities;
using AviatoCore.Infrastructure.Interfaces;
using AviatoCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviatoCore.Application.Services
{
    public class FlightService : IFlightService
    {
        private readonly IFlightRepository _flightRepository;

        public FlightService(IFlightRepository flightRepository)
        {
            _flightRepository = flightRepository;
        }

        public async Task<Flight> GetFlightAsync(int id)
        {
            return await _flightRepository.GetFlightAsync(id);
        }

        public async Task<IEnumerable<Flight>> GetFlightsByAirportIdAsync(int userAirportId)
        {
            var flights = await _flightRepository.GetAllFlightsAsync();
            return flights.Where(f => f.AirportId == userAirportId);
        }
        public async Task<IEnumerable<Flight>> GetUncheckedFlightsByAirportIdAsync(int userAirportId)
        {
            var flights = await _flightRepository.GetAllFlightsAsync();
            return flights.Where(f => f.AirportId == userAirportId && f.NeedsCheck==true);
        }

        public async Task AddFlightAsync(Flight flight)
        {
            await _flightRepository.AddFlightAsync(flight);
        }

        public async Task UpdateFlightAsync(Flight flight)
        {
            await _flightRepository.UpdateFlightAsync(flight);
        }

        public async Task DeleteFlightAsync(int id)
        {
            await _flightRepository.DeleteFlightAsync(id);
        }
    }
}
