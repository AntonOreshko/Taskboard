using System.Threading.Tasks;
using Activities.BusinessLayer.Interfaces;
using Common.DataContracts.Activities.Requests.Board;
using MassTransit;

namespace Activities.API.Consumers
{
    public class BoardCreateConsumer: IConsumer<BoardCreateRequest>
    {
        private readonly IActivitiesService _activitiesService;

        public BoardCreateConsumer()
        {

        }

        public BoardCreateConsumer(IActivitiesService activitiesService)
        {
            _activitiesService = activitiesService;
        }

        public async Task Consume(ConsumeContext<BoardCreateRequest> context)
        {
            var response = await _activitiesService.BoardCreate(context.Message);

            await context.RespondAsync(response);
        }
    }
}
