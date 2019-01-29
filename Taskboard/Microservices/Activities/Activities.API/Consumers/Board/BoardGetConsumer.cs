using Common.BusinessLayer.Interfaces;
using Common.DataContracts.Activities.Requests.Board;
using MassTransit;

namespace Activities.API.Consumers.Board
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

        public async System.Threading.Tasks.Task Consume(ConsumeContext<BoardGetRequest> context)
        {
            var response = await _activitiesService.BoardGet(context.Message);

            await context.RespondAsync(response);
        }
    }
}
