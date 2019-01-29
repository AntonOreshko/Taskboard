using System;
using Auth.API.Consumers;
using Auth.BusinessLayer;
using Auth.BusinessLayer.Interfaces;
using Auth.DomainModels.Creators;
using Auth.DomainModels.Interfaces;
using Auth.DomainModels.Models;
using Auth.Repository.EntityFramework;
using Auth.Repository.EntityFramework.Context;
using Auth.Repository.Interfaces;
using Common.DataContracts.Auth.Requests;
using Common.MassTransit.RabbitMq;
using Common.Repository;
using Common.Repository.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace Auth.API
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
                    options.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
                });

            services.AddDbContext<AuthContext>(
                options =>
                {
                    options.UseSqlServer(Configuration.GetConnectionString("HomeConnection"),
                        b => b.MigrationsAssembly("Auth.Repository"));
                });

            services.AddTransient<IEfRepository<User>, EfEfRepository<User>>();
            services.AddTransient<IUserEfRepository, EfEfUserRepository>();

            services
                .AddMassTransitForRabbitMq(Configuration)
                .RegisterConsumer<UserRegisterConsumer, UserRegisterRequest>()
                .RegisterConsumer<UserLoginConsumer, UserLoginRequest>();

            services.AddScoped<IPasswordCreator, PasswordCreator>();
            services.AddScoped<IUserCreator, UserCreator>();

            services.AddScoped<IAuthService, AuthService>();
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
                .ConnectConsumer<UserRegisterConsumer, UserRegisterRequest>()
                .ConnectConsumer<UserLoginConsumer, UserLoginRequest>();
        }
    }
}
