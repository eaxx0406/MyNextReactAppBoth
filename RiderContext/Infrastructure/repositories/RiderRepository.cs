using HorseRiderContext.Application.Interfaces;
using HorseRiderContext.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HorseRiderContext.Infrastructure.repositories
{

    public class RiderRepository : IRiderRepository
        {
            private readonly RiderDbContext _context;

            public RiderRepository(RiderDbContext context)
            {
                _context = context;
            }

            // Tilføjer bog til DbContext, men gemmer ikke endnu
            public async Task AddAsync(Rider rider)
            {
                await _context.Riders.AddAsync(rider);
            }

            public async Task<Rider?> GetByIdAsync(int id)
            {
                return await _context.Riders.FindAsync(id);
            }

            public async Task<List<Rider>> GetAllAsync()
            {
            //// Returner dummy data i stedet for database
            //var dummyRyttere = new List<Rider>
            //{
            //    new Rider { Id = 1, RiderName = "Mads", BirthYear = 1995, Email = "mads@example.com" },
            //    new Rider { Id = 2, RiderName = "Sofie", BirthYear = 2000, Email = "sofie@example.com" },
            //    new Rider { Id = 3, RiderName = "Jonas", BirthYear = 1998, Email = "jonas@example.com" }
            //};

            //return await Task.FromResult(dummyRyttere);

            return await _context.Riders.ToListAsync();
            }

            public async Task UpdateAsync(Rider rider)
            {
                _context.Riders.Update(rider);
                await Task.CompletedTask;
            }

            public async Task DeleteAsync(Rider rider)
            {
                _context.Riders.Remove(rider);
                await Task.CompletedTask;
            }

            public async Task SaveChangesAsync()
            {
                await _context.SaveChangesAsync();
            }
        }
    }

