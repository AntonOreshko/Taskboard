using System.Threading.Tasks;
using Activities.BusinessLayer.Interfaces;
using Common.DataContracts.Activities.Requests.Board;
using MassTransit;

namespace Activities.API.Consumers
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

        public async Task Consume(ConsumeContext<BoardGetListRequest> context)
        {
            var response = await _activitiesService.BoardGetList(context.Message);

            await context.RespondAsync(response);
        }
    }
}
