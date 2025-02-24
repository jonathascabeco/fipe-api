using CarFipe.Application.Services;

namespace CarFipe.Jobs
{
    public class CarFipeJob
    {
        private readonly FipeService _fipeService;

        public CarFipeJob(FipeService fipeService)
        {
            _fipeService = fipeService;
        }

        public async Task ExecuteAsync()
        {
            await _fipeService.FetchAndStoreCarsAsync();
        }
    }
}
