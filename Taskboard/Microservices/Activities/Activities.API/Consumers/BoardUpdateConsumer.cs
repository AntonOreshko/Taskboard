using System.Threading.Tasks;
using Activities.BusinessLayer.Interfaces;
using Common.DataContracts.Activities.Requests.Board;
using MassTransit;

namespace Activities.API.Consumers
{
    public class BoardUpdateConsumer: IConsumer<BoardUpdateRequest>
    {
        private readonly IActivitiesService _activitiesService;

        public BoardUpdateConsumer()
        {
            
        }

        public BoardUpdateConsumer(IActivitiesService activitiesService)
        {
            _activitiesService = activitiesService;
        }

        public async Task Consume(ConsumeContext<BoardUpdateRequest> context)
        {
            var response = await _activitiesService.BoardUpdate(context.Message);

            await context.RespondAsync(response);
        }
    }
}
