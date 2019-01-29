using System.Threading.Tasks;
using Activities.BusinessLayer.Interfaces;
using Common.DataContracts.Activities.Requests.Board;
using MassTransit;

namespace Activities.API.Consumers
{
    public class BoardGetConsumer: IConsumer<BoardGetRequest>
    {
        private readonly IActivitiesService _activitiesService;

        public BoardGetConsumer()
        {
            
        }

        public BoardGetConsumer(IActivitiesService activitiesService)
        {
            _activitiesService = activitiesService;
        }

        public async Task Consume(ConsumeContext<BoardGetRequest> context)
        {
            var response = await _activitiesService.BoardGet(context.Message);

            await context.RespondAsync(response);
        }
    }
}
