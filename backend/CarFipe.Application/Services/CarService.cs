using CarFipe.Domain.Entities;
using CarFipe.Domain.Interfaces;
using System.Net.Http.Json;

namespace CarFipe.Application.Services
{
    public class CarService
    {
        private readonly HttpClient _httpClient;
        private readonly ICarRepository _carRepository;

        public CarService(HttpClient httpClient, ICarRepository carRepository)
        {
            _httpClient = httpClient;
            _carRepository = carRepository;
        }

        
    }
}
