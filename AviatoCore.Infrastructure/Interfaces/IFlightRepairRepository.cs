using AviatoCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviatoCore.Infrastructure.Interfaces
{
    namespace AviatoCore.Infrastructure.Interfaces
    {
        public interface IFlightRepairRepository
        {
            Task<FlightRepair> GetFlightRepairAsync(int id);
            Task<IEnumerable<FlightRepair>> GetAllFlightRepairsAsync();
            Task AddFlightRepairAsync(FlightRepair flightRepair);
            Task UpdateFlightRepairAsync(FlightRepair flightRepair);
            Task DeleteFlightRepairAsync(int id);
            Task<int> GetFlightRepairsByPlaneIdAndServiceIdAsync(int planeId, int serviceId);
        }
    }
}
