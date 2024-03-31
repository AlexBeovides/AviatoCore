using AviatoCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviatoCore.Domain.Interfaces
{
    public interface IWorkerRepository
    {
        Task<Worker> GetWorkerAsync(string id);
        Task<IEnumerable<Worker>> GetAllWorkersAsync();
        Task AddWorkerAsync(Worker worker);
        Task UpdateWorkerAsync(Worker worker);
    }
}
