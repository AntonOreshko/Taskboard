using Common.BusinessLayer.Interfaces;
using Common.DataContracts.Activities.Requests.Task;
using MassTransit;

namespace Activities.API.Consumers.Task
{
    public class TaskGetConsumer: IConsumer<TaskGetRequest>
    {
        private readonly IActivitiesService _activitiesService;

        public TaskGetConsumer()
        {
            
        }

        public TaskGetConsumer(IActivitiesService activitiesService)
        {
            _activitiesService = activitiesService;
        }

        public async System.Threading.Tasks.Task Consume(ConsumeContext<TaskGetRequest> context)
        {
            var response = await _activitiesService.TaskGet(context.Message);

            await context.RespondAsync(response);
        }
    }
}
