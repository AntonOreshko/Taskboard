using Common.BusinessLayer.Interfaces;
using Common.DataContracts.Activities.Requests.Task;
using MassTransit;

namespace Activities.API.Consumers.Task
{
    public class TaskCreateConsumer: IConsumer<TaskCreateRequest>
    {
        private readonly IActivitiesService _activitiesService;

        public TaskCreateConsumer()
        {
            
        }

        public TaskCreateConsumer(IActivitiesService activitiesService)
        {
            _activitiesService = activitiesService;
        }

        public async System.Threading.Tasks.Task Consume(ConsumeContext<TaskCreateRequest> context)
        {
            var response = await _activitiesService.TaskCreate(context.Message);

            await context.RespondAsync(response);
        }
    }
}
