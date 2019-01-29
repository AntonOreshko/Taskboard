using Common.BusinessLayer.Interfaces;
using Common.DataContracts.Activities.Requests.Task;
using MassTransit;

namespace Activities.API.Consumers.Task
{
    public class TaskDeleteConsumer: IConsumer<TaskDeleteRequest>
    {
        private readonly IActivitiesService _activitiesService;

        public TaskDeleteConsumer()
        {
            
        }

        public TaskDeleteConsumer(IActivitiesService activitiesService)
        {
            _activitiesService = activitiesService;
        }

        public async System.Threading.Tasks.Task Consume(ConsumeContext<TaskDeleteRequest> context)
        {
            var response = await _activitiesService.TaskDelete(context.Message);

            await context.RespondAsync(response);
        }
    }
}
