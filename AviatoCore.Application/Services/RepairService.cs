using AviatoCore.Application.DTOs;
using AviatoCore.Application.Interfaces;
using AviatoCore.Domain.Entities;
using AviatoCore.Infrastructure.Interfaces;
using AviatoCore.Infrastructure;
using AviatoCore.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AviatoCore.Application.Services
{
    public class RepairService : IRepairService
    {
        private readonly IFacilityRepository _facilityRepository;
        private readonly IServiceRepository _serviceRepository;
        private readonly IRepairRepository _repairRepository;
        private readonly ILogger<RepairService> _logger;

        public RepairService(IFacilityRepository facilityRepository,
            IServiceRepository serviceRepository,
            IRepairRepository repairRepository,
            ILogger<RepairService> logger)
        {
            _facilityRepository = facilityRepository;
            _serviceRepository = serviceRepository;
            _repairRepository = repairRepository;
            _logger = logger;
        }

        private async Task<Service> GetServiceAsync(int id)
        {
            var service = await _serviceRepository.GetServiceAsync(id);
            if (service == null)
            {
                throw new Exception("Service not found.");
            }
            return service;
        }

        private async Task<Facility> GetFacilityAsync(int id, int userAirportId)
        {
            var facility = await _facilityRepository.GetFacilityAsync(id);
            if (facility == null || facility.AirportId != userAirportId)
            {
                throw new Exception("Facility not found.");
            }
            return facility;
        }

        public async Task<RepairDto> GetRepairAsync(int id, int userAirportId)
        {
            var service = await GetServiceAsync(id);
            var repair = await _repairRepository.GetRepairAsync(id);
            if (repair == null)
            {
                throw new Exception("Repair not found.");
            }

            await GetFacilityAsync(service.FacilityId, userAirportId);

            return new RepairDto
            {
                Id = service.Id,
                Name = service.Name,
                Description = service.Description,
                ImgUrl = service.ImgUrl,
                Price = service.Price,
                FacilityId = service.FacilityId,
                IsDeleted = service.IsDeleted,
                RepairTypeId = repair.RepairTypeId
            };
        }

        public async Task<IEnumerable<RepairDto>> GetRepairsByAirportIdAsync(int userAirportId)
        {
            var repairs = await _repairRepository.GetAllRepairsAsync();
            var repairList = repairs.ToList();

            var repairDtos = new List<RepairDto>();

            foreach (var repair in repairList)
            {
                try
                {
                    var service = await GetServiceAsync(repair.ServiceId);
                    await _facilityRepository.GetFacilityAsync(service.FacilityId); // implicit validation

                    repairDtos.Add(new RepairDto
                    {
                        Id = service.Id,
                        Name = service.Name,
                        Description = service.Description,
                        ImgUrl = service.ImgUrl,
                        Price = service.Price,
                        FacilityId = service.FacilityId,
                        IsDeleted = service.IsDeleted,
                        RepairTypeId = repair.RepairTypeId
                    });
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Failed to process repair with ID {repair.Id}");
                }
            }

            return repairDtos;
        }

        public async Task AddRepairAsync(RepairDto repairDto, int userAirportId)
        {
            await GetFacilityAsync(repairDto.FacilityId , userAirportId); // implicit validation

            var service = new Service
            {
                Name = repairDto.Name,
                Description = repairDto.Description,
                ImgUrl = repairDto.ImgUrl,
                Price = repairDto.Price,
                FacilityId = repairDto.FacilityId,
                IsDeleted = repairDto.IsDeleted
            };

            await _serviceRepository.AddServiceAsync(service);


            var repair = new Repair
            {
                Id = service.Id,
                ServiceId = service.Id,
                RepairTypeId = repairDto.RepairTypeId
            };

            await _repairRepository.AddRepairAsync(repair);
        }

        public async Task UpdateRepairAsync(RepairDto repairDto, int userAirportId)
        {
            await GetFacilityAsync(repairDto.FacilityId, userAirportId); // implicit validation

            var service = await _serviceRepository.GetServiceAsync(repairDto.Id);
            var repair = await _repairRepository.GetRepairAsync(repairDto.Id);

            service.Name = repairDto.Name;
            service.Description = repairDto.Description;
            service.ImgUrl = repairDto.ImgUrl;
            service.Price = repairDto.Price;
            service.FacilityId = repairDto.FacilityId;
            service.IsDeleted = repairDto.IsDeleted;

            repair.RepairTypeId = repairDto.RepairTypeId;

            await _serviceRepository.UpdateServiceAsync(service);
            await _repairRepository.UpdateRepairAsync(repair);
        }

        public async Task DeleteRepairAsync(int id, int userAirportId)
        {
            var service = await GetServiceAsync(id);  
            await GetFacilityAsync(service.FacilityId, userAirportId);  // implicit validation

            await _serviceRepository.DeleteServiceAsync(id);
        }
    }
}
