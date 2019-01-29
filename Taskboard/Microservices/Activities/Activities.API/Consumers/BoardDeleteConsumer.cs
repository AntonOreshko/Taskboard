using System;
using System.Threading.Tasks;
using Activities.BusinessLayer.Interfaces;
using Activities.DomainModels.Interfaces;
using Activities.Repository.Interfaces;
using Common.DataContracts.Activities.Requests.Board;
using Common.DataContracts.Activities.Responses.Board;
using Common.Errors;
using MassTransit;

namespace Activities.API.Consumers
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

        public async Task Consume(ConsumeContext<BoardDeleteRequest> context)
        {
            var response = await _activitiesService.BoardDelete(context.Message);

            await context.RespondAsync(response);
        }
    }
}
