using AviatoCore.Application.DTOs;
using AviatoCore.Domain.Entities;
using AviatoCore.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviatoCore.Application.Interfaces
{
    public interface IWorkerService
    {
        Task<WorkerDto> GetWorkerAsync(string id);
        Task<IEnumerable<WorkerDto>> GetAllWorkersAsync();
        Task<IdentityResult> AddWorkerAsync(WorkerDto workerDto);
        Task UpdateWorkerAsync(WorkerDto workerDto);
        Task DeleteWorkerAsync(string id);
    }
}
