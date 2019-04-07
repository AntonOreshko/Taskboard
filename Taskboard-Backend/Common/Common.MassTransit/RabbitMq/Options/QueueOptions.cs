namespace Common.MassTransit.RabbitMq.Options
{
    public class QueueOptions
    {
        public bool AutoDelete { get; set; }

        public bool Durable { get; set; }

        public bool Exclusive { get; set; }
    }
}