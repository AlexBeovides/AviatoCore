﻿using AviatoCore.Domain.Entities; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviatoCore.Application.Interfaces
{
    public interface IFlightService
    {
        Task<Flight> GetFlightAsync(int id);
        Task<IEnumerable<Flight>> GetFlightsByAirportIdAsync(int userAirportId);
        Task<IEnumerable<Flight>> GetUncheckedFlightsByAirportIdAsync(int userAirportId);
        Task AddFlightAsync(Flight flight);
        Task UpdateFlightAsync(Flight flight);
        Task DeleteFlightAsync(int id);
        Task UncheckFlightAsync(int userAirportId, int id);
    }
}
