namespace Common.MassTransit.RabbitMq.Options
{
    public class ExchangeOptions
    {
        public bool Durable { get; set; }

        public bool AutoDelete { get; set; }

        public string Topic { get; set; }
    }
}