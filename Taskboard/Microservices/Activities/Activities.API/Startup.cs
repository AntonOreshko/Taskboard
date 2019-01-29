using System;
using Activities.API.Consumers;
using Activities.BusinessLayer;
using Activities.BusinessLayer.Interfaces;
using Activities.DomainModels.Creators;
using Activities.DomainModels.Interfaces;
using Activities.DomainModels.Models;
using Activities.Repository.Interfaces;
using Activities.Repository.MongoDb;
using Common.DataContracts.Activities.Requests.Board;
using Common.MassTransit.RabbitMq;
using Common.MongoDb;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace Activities.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                });

            services.AddMongoDb(Configuration);

            services.AddTransient<IBoardCreator, BoardCreator>();

            services.AddScoped<MongoDbContext<Board>>();

            services.AddTransient<IBoardRepository, BoardRepository>();

            services
                .AddMassTransitForRabbitMq(Configuration)
                .RegisterConsumer<BoardCreateConsumer, BoardCreateRequest>()
                .RegisterConsumer<BoardUpdateConsumer, BoardUpdateRequest>()
                .RegisterConsumer<BoardDeleteConsumer, BoardDeleteRequest>()
                .RegisterConsumer<BoardGetConsumer, BoardGetRequest>()
                .RegisterConsumer<BoardGetListConsumer, BoardGetListRequest>();

            services.AddScoped<IActivitiesService, ActivitiesService>();

            services.AddMassTransitForRabbitMq(Configuration);
        }


        public void Configure(IApplicationBuilder app,
            IHostingEnvironment env,
            IServiceProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //else
            //{
            //    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //    app.UseHsts();
            //}

            //app.UseHttpsRedirection();
            app.UseMvc();

            provider
                .ConnectConsumer<BoardCreateConsumer, BoardCreateRequest>()
                .ConnectConsumer<BoardUpdateConsumer, BoardUpdateRequest>()
                .ConnectConsumer<BoardDeleteConsumer, BoardDeleteRequest>()
                .ConnectConsumer<BoardGetConsumer, BoardGetRequest>()
                .ConnectConsumer<BoardGetListConsumer, BoardGetListRequest>();
        }
    }
}
