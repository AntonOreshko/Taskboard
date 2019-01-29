using System;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace Common.MassTransit.RabbitMq
{
    internal class ConsumerResolver
    {
        private readonly IServiceProvider _serviceProvider;

        public ConsumerResolver(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public TC CreateConsumer<TC, TM>()
            where TC : class, IConsumer<TM>, new()
            where TM : class
        {
            var scope = _serviceProvider.CreateScope().ServiceProvider;

            return scope.GetRequiredService<TC>();
        }
    }
}
