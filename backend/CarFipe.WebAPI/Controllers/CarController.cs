using CarFipe.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class CarsController : ControllerBase
{
    private readonly ICarRepository _carRepository;

    public CarsController(ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetCars()
    {
        var cars = await _carRepository.GetAllCarsAsync();
        return Ok(cars);
    }
}