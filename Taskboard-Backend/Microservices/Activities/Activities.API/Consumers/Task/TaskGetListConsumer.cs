using Common.BusinessLayer.Interfaces;
using Common.DataContracts.Activities.Requests.Task;
using MassTransit;

namespace Activities.API.Consumers.Task
{
    public class TaskGetListConsumer: IConsumer<TaskGetListRequest>
    {
        private readonly IActivitiesService _activitiesService;

        public TaskGetListConsumer()
        {
            
        }

        public TaskGetListConsumer(IActivitiesService activitiesService)
        {
            _activitiesService = activitiesService;
        }

        public async System.Threading.Tasks.Task Consume(ConsumeContext<TaskGetListRequest> context)
        {
            var response = await _activitiesService.TaskGetList(context.Message);

            await context.RespondAsync(response);
        }
    }
}