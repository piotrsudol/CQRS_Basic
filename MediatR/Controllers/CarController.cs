using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Cars.Commands;
using Services.Cars.Queries;
using Services.Models;

namespace MediatR.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : ControllerBase
    {
        private readonly IMediator mediator;

        public CarController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public Task<IEnumerable<Car>> Index() {
            return mediator.Send(new GetAllCarsQuery());
        }

        [HttpPost]
        public Task<Response<Car>> Index([FromBody] CreateCarCommand command) {
            return mediator.Send(command);
        }
    }
}