using Services.Models;
using Services.Wrappers;

namespace Services.Cars.Commands
{
    public class CreateCarCommand : IRequestWrapper<Car> { }
    public class CreateCarCommandHandler : IHandlerWrapper<CreateCarCommand, Car>
    {
        public Task<Response<Car>> Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
            if (false) {
                return Task.FromResult(Response.Fail<Car>("Already exists"));
            }

            return Task.FromResult(Response.Ok(new Car { Name = "Created" }, "Car created"));
        }
    }
}
