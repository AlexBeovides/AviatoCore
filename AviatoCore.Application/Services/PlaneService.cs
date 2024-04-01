using AviatoCore.Application.Interfaces;
using AviatoCore.Domain.Entities;
using AviatoCore.Domain.Interfaces;
using AviatoCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviatoCore.Application.Services
{
    public class PlaneService : IPlaneService
    {
        private readonly IPlaneRepository _planeRepository;

        public PlaneService(IPlaneRepository planeRepository)
        {
            _planeRepository = planeRepository;
        }

        public async Task<Plane> GetPlaneAsync(int id)
        {
            return await _planeRepository.GetPlaneAsync(id);
        }

        public async Task<IEnumerable<Plane>> GetAllPlanesAsync()
        {
            return await _planeRepository.GetAllPlanesAsync();
        } 
        public async Task<IEnumerable<Plane>> GetPlanesByOwnerIdAsync(string userId)
        {
            var planes = await _planeRepository.GetAllPlanesAsync();
            var clientPlanes = planes.Where(p => p.OwnerId == userId && p.IsDeleted == false);

            return clientPlanes;
        }

        public async Task AddPlaneAsync(Plane plane)
        {
            await _planeRepository.AddPlaneAsync(plane);
        }

        public async Task UpdatePlaneAsync(Plane plane)
        {
            await _planeRepository.UpdatePlaneAsync(plane);
        }

        public async Task DeletePlaneAsync(int id)
        {
            await _planeRepository.DeletePlaneAsync(id);
        }
    }
}
