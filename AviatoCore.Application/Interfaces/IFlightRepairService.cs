using AviatoCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviatoCore.Application.Interfaces
{
    public interface IFlightRepairService
    {
        Task<FlightRepair> GetFlightRepairAsync(int id);
        Task<IEnumerable<FlightRepair>> GetAllFlightRepairsAsync();
        Task AddFlightRepairAsync(FlightRepair flightRepair);
        Task UpdateFlightRepairAsync(FlightRepair flightRepair);
        Task DeleteFlightRepairAsync(int id);
    }
}
