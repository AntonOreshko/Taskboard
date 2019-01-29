using Common.BusinessLayer.Interfaces;
using Common.DataContracts.Activities.Requests.Board;
using MassTransit;

namespace Activities.API.Consumers.Board
{
    public class BoardGetListConsumer: IConsumer<BoardGetListRequest>
    {
        private readonly IActivitiesService _activitiesService;

        public BoardGetListConsumer()
        {
            
        }

        public BoardGetListConsumer(IActivitiesService activitiesService)
        {
            _activitiesService = activitiesService;
        }

        public async System.Threading.Tasks.Task Consume(ConsumeContext<BoardGetListRequest> context)
        {
            var response = await _activitiesService.BoardGetList(context.Message);

            await context.RespondAsync(response);
        }
    }
}
