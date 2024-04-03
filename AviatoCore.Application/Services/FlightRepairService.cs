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
using AviatoCore.Infrastructure.Interfaces.AviatoCore.Infrastructure.Interfaces;
using AviatoCore.Infrastructure.Repositories;

namespace AviatoCore.Application.Services
{
    public class FlightRepairService : IFlightRepairService
    {
        private readonly IFlightRepairRepository _flightRepairRepository;
        private readonly IFlightRepository _flightRepository;
        private readonly IServiceRepository _serviceRepository;
        private readonly IRepairRepository _repairRepository;

        public FlightRepairService(IFlightRepairRepository flightRepairRepository,
            IServiceRepository serviceRepository,
         IRepairRepository repairRepository,
         IFlightRepository flightRepository
            )
        {
            _flightRepairRepository = flightRepairRepository;
            _serviceRepository= serviceRepository;
            _repairRepository = repairRepository;
            _flightRepository = flightRepository;
        }

        public async Task<FlightRepair> GetFlightRepairAsync(int id)
        {
            return await _flightRepairRepository.GetFlightRepairAsync(id);
        }

        public async Task<IEnumerable<FlightRepair>> GetAllFlightRepairsAsync()
        {
            return await _flightRepairRepository.GetAllFlightRepairsAsync();
        }

        public async Task AddFlightRepairAsync(FlightRepair flightRepair)
        {
            // Obtener el vuelo relacionado
            var flight = await _flightRepository.GetFlightAsync(flightRepair.FlightId);
            var repair = await _repairRepository.GetRepairAsync(flightRepair.RepairId);
            var service = await _serviceRepository.GetServiceAsync(repair.ServiceId);
            

            // Calcular la duración en horas
            var duration = (flightRepair.FinishedAt - flightRepair.StartedAt).TotalHours;
            flightRepair.RepairCost = service.Price * duration;

            // Verificar si es el primer servicio
            var previousRepairs = await _flightRepairRepository.GetFlightRepairsByPlaneIdAndServiceIdAsync(flight.PlaneId, service.Id);
            if (previousRepairs==0)
            {
                // Si es el primer servicio, se cobra un 1% adicional por cada hora de servicio
                flightRepair.RepairCost += flightRepair.RepairCost * 0.01 * duration;
            }

            // Si la fecha de terminación es posterior a la fecha de salida planificada, 
            // el costo de los servicios que ocasionaron la demora será disminuido en un 1% por hora
            if (flightRepair.FinishedAt > flight.DepartureTime)
            {
                var delayHours = (flightRepair.FinishedAt - flight.DepartureTime).TotalHours;
                flightRepair.RepairCost -= flightRepair.RepairCost * 0.01 * delayHours;
            }

            await _flightRepairRepository.AddFlightRepairAsync(flightRepair);
        }

        public async Task UpdateFlightRepairAsync(FlightRepair flightRepair)
        {
            await _flightRepairRepository.UpdateFlightRepairAsync(flightRepair);
        }

        public async Task DeleteFlightRepairAsync(int id)
        {
            await _flightRepairRepository.DeleteFlightRepairAsync(id);
        }
    }
}
