using System;

namespace Common.MassTransit.RabbitMq.Options
{
    public class RabbitMqOptions
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public int Port { get; set; }

        public string VirtualHost { get; set; }

        public string Hostname { get; set; }

        public TimeSpan RequestTimeout { get; set; }

        public TimeSpan PublishConfirmTimeout { get; set; }

        public TimeSpan RecoveryInterval { get; set; }

        public bool PersistentDeliveryMode { get; set; }

        public bool AutoCloseConnection { get; set; }

        public bool AutomaticRecovery { get; set; }

        public bool TopologyRecovery { get; set; }

        public ExchangeOptions Exchange { get; set; }

        public QueueOptions Queue { get; set; }

        public RabbitMqOptions()
        {
            Exchange = new ExchangeOptions();
            Queue = new QueueOptions();
        }
    }
}
