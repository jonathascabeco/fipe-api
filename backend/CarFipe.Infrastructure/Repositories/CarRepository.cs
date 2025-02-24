using CarFipe.Domain.Entities;
using CarFipe.Domain.Interfaces;
using CarFipe.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CarFipe.Infrastructure.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly CarFipeDbContext _context;

        public CarRepository(CarFipeDbContext context)
        {
            _context = context;
        }

        public async Task<List<Car>> GetAllCarsAsync()
        {
            return await _context.Cars.ToListAsync();
        }

        public async Task<int> GetMaxCarIdAsync()
        {
            return await _context.Cars.MaxAsync(c => (int?)c.Id) ?? 0;
        }

     
        public async Task UpsertCarAsync(Car car)
        {
            try
            {
                var existingCar = await _context.Cars.FindAsync(car.Id);
                if (existingCar == null)
                {
                    _context.Cars.Add(car);
                }
                else
                {
                    existingCar.Name = car.Name;
                    _context.Cars.Update(existingCar);
                }

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao salvar no banco: {ex.Message}");
            }
        }
    }
}
