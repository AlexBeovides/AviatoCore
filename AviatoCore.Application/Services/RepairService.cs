using AviatoCore.Application.DTOs;
using AviatoCore.Application.Interfaces;
using AviatoCore.Domain.Entities;
using AviatoCore.Domain.Interfaces;
using AviatoCore.Infrastructure;
using AviatoCore.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviatoCore.Application.Services
{
    public class RepairService : IRepairService
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IRepairRepository _repairRepository;

        public RepairService(IServiceRepository serviceRepository,
            IRepairRepository repairRepository)
        {
            _serviceRepository = serviceRepository;
            _repairRepository = repairRepository;
        }

        public async Task<RepairDto> GetRepairAsync(int id)
        {
            var service = await _serviceRepository.GetServiceAsync(id);
            var repair = await _repairRepository.GetRepairAsync(id);

            return new RepairDto
            {
                Id = service.Id,
                Name = service.Name,
                Price = service.Price,
                FacilityId = service.FacilityId,
                IsDeleted = service.IsDeleted,
                RepairTypeId = repair.RepairTypeId
            };
        }

        public async Task<IEnumerable<RepairDto>> GetAllRepairsAsync()
        {
            var repairs = await _repairRepository.GetAllRepairsAsync();

            // Convert the services to a list
            var repairList = repairs.ToList();

            // Create a list to store the RepairDto objects
            var repairDtos = new List<RepairDto>();

            foreach (var repair in repairList)
            {
                var service = await _serviceRepository.GetServiceAsync(repair.ServiceId);

                if (service != null)
                {
                    // Create a RepairDto object and add it to the list
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
            }

            return repairDtos;
        }

        public async Task AddRepairAsync(RepairDto repairDto)
        {
            var service = new Service
            {
                Name = repairDto.Name,
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

        public async Task UpdateRepairAsync(RepairDto repairDto)
        {
            var service = await _serviceRepository.GetServiceAsync(repairDto.Id);
            var repair = await _repairRepository.GetRepairAsync(repairDto.Id);

            service.Name = repairDto.Name;
            service.Price = repairDto.Price;
            service.FacilityId = repairDto.FacilityId;
            service.IsDeleted = repairDto.IsDeleted;

            repair.RepairTypeId = repairDto.RepairTypeId;

            await _serviceRepository.UpdateServiceAsync(service);
            await _repairRepository.UpdateRepairAsync(repair);
        }

        public async Task DeleteRepairAsync(int id)
        {
            await _serviceRepository.DeleteServiceAsync(id);
        }
    }
}
