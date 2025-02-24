using System.Net.Http.Json;
using CarFipe.Application.Services.DTOs;
using CarFipe.Domain.Entities;
using CarFipe.Domain.Interfaces;

namespace CarFipe.Application.Services
{
    public class FipeService
    {
        private readonly HttpClient _httpClient;
        private readonly ICarRepository _carRepository;

        public FipeService(HttpClient httpClient, ICarRepository carRepository)
        {
            _httpClient = httpClient;
            _carRepository = carRepository;
        }

        public async Task FetchAndStoreCarsAsync()
        {
            int lastStoredId = await _carRepository.GetMaxCarIdAsync();

            var carList = await _httpClient.GetFromJsonAsync<List<FipeCarDto>>("https://parallelum.com.br/fipe/api/v1/carros/marcas");

            if (carList != null)
            {
                var orderedCarList = carList.OrderBy(p => p.Codigo).ToList();

                var newCars = orderedCarList
                    .Where(car => car.Codigo > lastStoredId)
                    .Select(car => new Car
                    {
                        Id = car.Codigo,
                        Name = car.Nome
                    }).ToList();

                foreach (var car in newCars)
                {
                    await _carRepository.UpsertCarAsync(car);
                }
            }
        }
    }
}
