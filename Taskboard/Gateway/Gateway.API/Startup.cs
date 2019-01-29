using System;
using Common.DataContracts.Activities.Requests.Board;
using Common.DataContracts.Activities.Responses.Board;
using Common.DataContracts.Auth.Requests;
using Common.DataContracts.Auth.Responses;
using Common.JWT;
using Common.MassTransit.RabbitMq;
using Gateway.BusinessLayer.Activities;
using Gateway.BusinessLayer.Auth;
using Gateway.BusinessLayer.Interfaces.Activities;
using Gateway.BusinessLayer.Interfaces.Auth;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using BoardUpdateResponse = Common.DataContracts.Activities.Responses.Board.BoardUpdateResponse;

namespace Gateway.API
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
            services
                .AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    options.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
                });

            services
                .AddMassTransitForRabbitMq(Configuration)
                .AddRequestClient<UserRegisterRequest, UserRegisterResponse>(Configuration)
                .AddRequestClient<UserLoginRequest, UserLoginResponse>(Configuration)
                .AddRequestClient<BoardCreateRequest, BoardCreateResponse>(Configuration)
                .AddRequestClient<BoardUpdateRequest, BoardUpdateResponse>(Configuration)
                .AddRequestClient<BoardDeleteRequest, BoardDeleteResponse>(Configuration)
                .AddRequestClient<BoardGetListRequest, BoardGetListResponse>(Configuration)
                .AddRequestClient<BoardGetRequest, BoardGetResponse>(Configuration);

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IActivitiesService, ActivitiesService>();
            services.AddJwtAuthentication(Configuration);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
            IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //else
            //{
            //    app.UseHsts();
            //}

            //app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
