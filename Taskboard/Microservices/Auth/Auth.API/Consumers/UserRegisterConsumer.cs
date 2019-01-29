using System.Threading.Tasks;
using Auth.BusinessLayer.Interfaces;
using Common.DataContracts.Auth.Requests;
using MassTransit;

namespace Auth.API.Consumers
{
    public class UserRegisterConsumer: IConsumer<UserRegisterRequest>
    {
        private readonly IAuthService _authService;

        public UserRegisterConsumer()
        {
            
        }

        public UserRegisterConsumer(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task Consume(ConsumeContext<UserRegisterRequest> context)
        {
            var response = await _authService.Register(context.Message);

            await context.RespondAsync(response);
        }
    }
}
