using CarFipe.Domain.Entities;

namespace CarFipe.Domain.Interfaces
{
    public interface ICarRepository
    {
        Task<List<Car>> GetAllCarsAsync();
        Task<int> GetMaxCarIdAsync();
        Task UpsertCarAsync(Car car);
    }
}
