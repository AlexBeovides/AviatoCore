using AviatoCore.Domain.Entities;
using AviatoCore.Infrastructure.DTOs;
using AviatoCore.Infrastructure;
using AviatoCore.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore; // Add this
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviatoCore.Infrastructure.Interfaces
{
    // IStatsRepository.cs
    // StatsRepository.cs
    public class StatsRepository : IStatsRepository
    {
        private readonly AviatoDbContext _context;

        public StatsRepository(AviatoDbContext context)
        {
            _context = context;
        }

        public async Task<List<AirportRepairServiceDto>> GetRepairServicesAsync()
        {
            var repairServices = await (from r in _context.Repairs
                                        join s in _context.Services on r.ServiceId equals s.Id
                                        join i in _context.Facilities on s.FacilityId equals i.Id
                                        join a in _context.Airports on i.AirportId equals a.Id
                                        select new AirportRepairServiceDto
                                        {
                                            Name = a.Name,
                                            Latitude = a.Latitude,
                                            Longitude = a.Longitude
                                        }).ToListAsync();

            return repairServices;
        }

        public async Task<List<AirportMajorRepairCountDto>> GetMajorRepairsCountAsync()
        {
            var majorRepairsPerAirport = await (from r in _context.Repairs
                                                join rt in _context.RepairTypes on r.RepairTypeId equals rt.Id
                                                join fr in _context.FlightRepairs on r.Id equals fr.RepairId
                                                join s in _context.Services on r.ServiceId equals s.Id
                                                join f in _context.Facilities on s.FacilityId equals f.Id
                                                join a in _context.Airports on f.AirportId equals a.Id
                                                where rt.Name == "Capital"
                                                group a by a.Name into g
                                                select new AirportMajorRepairCountDto
                                                {
                                                    AirportName = g.Key,
                                                    CapitalRepairCount = g.Count()
                                                }).ToListAsync();
            return majorRepairsPerAirport;
        }

        public async Task<List<AirportClientDto>> GetCustomersByTypeAsync()
        {
            var clients = await (from f in _context.Flights
                                 join p in _context.Planes on f.PlaneId equals p.Id
                                 join c in _context.Clients on p.OwnerId equals c.ClientId
                                 join u in _context.Users on c.UserId equals u.Id
                                 join ct in _context.ClientTypes on c.ClientTypeId equals ct.Id
                                 join or in _context.OwnersRole on f.OwnerRoleId equals or.Id
                                 where f.AirportId == _context.Airports.FirstOrDefault(a => a.Name == "José Martí").Id
                                 && or.Name == "Captain"
                                 select new AirportClientDto { ClientName = u.Name, ClientType = ct.Name }).ToListAsync();
            return clients;
        }

        public async Task<List<AirportServiceCountDto>> GetLeastVisitedSince2010Async()
        {
            var result = await (from f in _context.Flights
                                join a in _context.Airports on f.AirportId equals a.Id
                                join fa in _context.Facilities on a.Id equals fa.AirportId
                                join s in _context.Services on fa.Id equals s.FacilityId
                                where f.ArrivalTime.Year > 2010
                                group s by new { a.Id, a.Name } into g
                                orderby g.Count()
                                select new AirportServiceCountDto
                                {
                                    AirportId = g.Key.Id,
                                    AirportName = g.Key.Name,
                                    ServicesCount = g.Count()
                                }).Take(3).ToListAsync();
            return result;
        }

        public async Task<AirportInefficientRepairServiceDto> GetAverageRepairCostAsync()
        {
            var data = await (from r in _context.Repairs
                              join s in _context.Services on r.ServiceId equals s.Id
                              join f in _context.Facilities on s.FacilityId equals f.Id
                              join a in _context.Airports on f.AirportId equals a.Id
                              join rv in _context.Reviews on s.Id equals rv.ServiceId
                              where a.Name == "José Martí"
                              select new { r, rv, s, a }).ToListAsync();

            var groupedData = data.GroupBy(x => x.a.Name);

            double? result = groupedData.Select(g =>
            {
                var avgRatingLastYear = g.Where(x => x.rv.ReviewedAt.Year == DateTime.Now.Year - 1).Average(x => x.rv.Rating);
                var avgRatingOverall = g.Average(x => x.rv.Rating);
                if (avgRatingLastYear < 1 && avgRatingOverall < 2)
                {
                    return g.Average(x => x.s.Price);
                }
                else
                {
                    return (double?)null;
                }
            }).FirstOrDefault(x => x.HasValue);

            return new AirportInefficientRepairServiceDto { AverageCost = result ?? 0.0 };
        }
    }
}
