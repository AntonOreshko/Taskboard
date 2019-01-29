using System;
using Common.DataContracts.Interfaces;
using Common.MassTransit.RabbitMq.Options;
using MassTransit;
using MassTransit.RabbitMqTransport;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Common.MassTransit.RabbitMq
{
    public static class Extensions
    {
        public static IServiceCollection AddMassTransitForRabbitMq(this IServiceCollection services, IConfiguration configuration)
        {
            var options = new RabbitMqOptions();
            var section = configuration.GetSection("rabbitmq");
            section.Bind(options);

            IRabbitMqHost host = null;

            var bus = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                host = cfg.Host(new Uri(options.Hostname), c =>
                {
                    c.Username(options.Username);
                    c.Password(options.Password);
                });
            });

            services.AddSingleton<IPublishEndpoint>(bus);
            services.AddSingleton<ISendEndpointProvider>(bus);
            services.AddSingleton<IBus>(bus);
            services.AddSingleton<IRabbitMqHost>(host);
            services.AddSingleton<ConsumerResolver>();
            
            bus.Start();

            return services;
        }

        public static IServiceCollection RegisterConsumer<TC, TM>(this IServiceCollection services)
            where TC : class, IConsumer<TM>, new()
            where TM : class
        {
            services.AddScoped<TC>();

            return services;
        }

        public static IServiceProvider ConnectConsumer<TC, TM>(this IServiceProvider provider)
            where TC : class, IConsumer<TM>, new()
            where TM : class
        {
            var host = provider.GetRequiredService<IRabbitMqHost>();
            var resolver = provider.GetRequiredService<ConsumerResolver>();

            host.ConnectReceiveEndpoint(TypeName<TM>(), x =>
            {
                x.Consumer<TC>(() => resolver.CreateConsumer<TC, TM>());

            });

            return provider;
        }

        public static IServiceCollection AddRequestClient<TReq, TRes>(this IServiceCollection services, IConfiguration configuration)
            where TReq : class, IRequest
            where TRes : class, IResponse
        {
            var options = new RabbitMqOptions();
            var section = configuration.GetSection("rabbitmq");
            section.Bind(options);

            services.AddScoped<IRequestClient<TReq, TRes>>
            (
                x => new MessageRequestClient<TReq, TRes>
                (
                    x.GetRequiredService<IBus>(),
                    new Uri(options.Hostname + TypeName<TReq>()),
                    options.RequestTimeout,
                    options.RequestTimeout
                )
            );

            return services;
        }

        public static IServiceCollection AddPublishClient<TEvent, TRes>(this IServiceCollection services, IConfiguration configuration)
            where TEvent : class, IEvent
            where TRes : class, IResponse
        {
            var options = new RabbitMqOptions();
            var section = configuration.GetSection("rabbitmq");
            section.Bind(options);

            services.AddScoped<IRequestClient<TEvent, TRes>>
            (
                x => new PublishRequestClient<TEvent, TRes>
                (
                    x.GetRequiredService<IBus>(),
                    options.RequestTimeout,
                    options.RequestTimeout
                )
            );

            return services;
        }

        private static string TypeName<T>()
        {
            return typeof(T).FullName;
        }
    }
}
