using Common.BusinessLayer.Interfaces;
using Common.DataContracts.Activities.Requests.Task;
using MassTransit;

namespace Activities.API.Consumers.Task
{
    public class TaskCompleteConsumer: IConsumer<TaskCompleteRequest>
    {
        private readonly IActivitiesService _activitiesService;

        public TaskCompleteConsumer()
        {
            
        }

        public TaskCompleteConsumer(IActivitiesService activitiesService)
        {
            _activitiesService = activitiesService;
        }

        public async System.Threading.Tasks.Task Consume(ConsumeContext<TaskCompleteRequest> context)
        {
            var response = await _activitiesService.TaskComplete(context.Message);

            await context.RespondAsync(response);
        }
    }
}