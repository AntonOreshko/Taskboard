using Common.BusinessLayer.Interfaces;
using Common.DataContracts.Activities.Requests.Board;
using MassTransit;

namespace Activities.API.Consumers.Board
{
    public class BoardDeleteConsumer: IConsumer<BoardDeleteRequest>
    {
        private readonly IActivitiesService _activitiesService;

        public BoardDeleteConsumer()
        {

        }        

        public BoardDeleteConsumer(IActivitiesService activitiesService)
        {
            _activitiesService = activitiesService;
        }

        public async System.Threading.Tasks.Task Consume(ConsumeContext<BoardDeleteRequest> context)
        {
            var response = await _activitiesService.BoardDelete(context.Message);

            await context.RespondAsync(response);
        }
    }
}
