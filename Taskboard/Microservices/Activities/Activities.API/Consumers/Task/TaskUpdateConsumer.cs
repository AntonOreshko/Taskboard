using Common.BusinessLayer.Interfaces;
using Common.DataContracts.Activities.Requests.Task;
using MassTransit;

namespace Activities.API.Consumers.Task
{
    public class TaskUpdateConsumer: IConsumer<TaskUpdateRequest>
    {
        private readonly IActivitiesService _activitiesService;

        public TaskUpdateConsumer()
        {
            
        }

        public TaskUpdateConsumer(IActivitiesService activitiesService)
        {
            _activitiesService = activitiesService;
        }

        public async System.Threading.Tasks.Task Consume(ConsumeContext<TaskUpdateRequest> context)
        {
            var response = await _activitiesService.TaskUpdate(context.Message);

            await context.RespondAsync(response);
        }
    }
}
