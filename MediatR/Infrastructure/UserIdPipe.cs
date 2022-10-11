using MediatR;
using Services;
using Services.Models;
using System.Security.Claims;

namespace WebApi.Infrastructure
{
    public class UserIdPipe<TIn, TOut> : IPipelineBehavior<TIn, TOut> where TIn : IRequest<TOut>
    {
        private readonly HttpContext httpContext;

        public UserIdPipe(IHttpContextAccessor accessor)
        {
            this.httpContext = accessor.HttpContext;
        }

        public async Task<TOut> Handle(TIn request, RequestHandlerDelegate<TOut> next, CancellationToken cancellationToken)
        {
            //var claim = httpContext.User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.NameIdentifier)).Value;
            if (request is BaseRequest br) {
                br.UserId = "Test";
            }

            var result = await next();

            if (result is Response<Car> carResponse) {
                carResponse.Data.Name += "Went through pipeline";
            }

            return result;
        }
    }
}
