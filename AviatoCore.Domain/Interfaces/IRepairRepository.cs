using AviatoCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviatoCore.Domain.Interfaces
{
    public interface IRepairRepository
    {
        Task<Repair> GetRepairAsync(int id);
        Task<IEnumerable<Repair>> GetAllRepairsAsync();
        Task AddRepairAsync(Repair repair);
        Task UpdateRepairAsync(Repair repair);
    }
}
