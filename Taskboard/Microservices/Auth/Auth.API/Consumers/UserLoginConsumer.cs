using System.Threading.Tasks;
using Common.BusinessLayer.Interfaces;
using Common.DataContracts.Auth.Requests;
using MassTransit;

namespace Auth.API.Consumers
{
    public class UserLoginConsumer: IConsumer<UserLoginRequest>
    {
        private readonly IAuthService _authService;

        public UserLoginConsumer()
        {
            
        }

        public UserLoginConsumer(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task Consume(ConsumeContext<UserLoginRequest> context)
        {
            var response = await _authService.Login(context.Message);

            await context.RespondAsync(response);
        }
    }
}
