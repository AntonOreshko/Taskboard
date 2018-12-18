using BusinessLayer.Services;
using BusinessLayer.Services.Interfaces;
using DomainModels.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using RepositoryLayer.EntityFramework;
using RepositoryLayer.EntityFramework.Context;
using RepositoryLayer.Repository;
using System.Text;
using AutoMapper;
using BusinessLayer.Services.Interfaces.Mail;
using BusinessLayer.Services.Mail;

namespace WebApi
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddCors();

            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                options.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
            });

            services.AddDbContext<TaskboardContext>(
                options =>
                {
                    options.UseSqlServer(Configuration.GetConnectionString("HomeConnection"),
                        b => b.MigrationsAssembly("WebApi"));
                });

            services.AddAutoMapper();

            ConfigureEfRepositories(services);
            ConfigureItemServices(services);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.ASCII.GetBytes(Configuration.GetSection("AppSettings:Token").Value)
                        ),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                    };
                });
        }

        public void ConfigureEfRepositories(IServiceCollection services)
        {
            services.AddTransient<IRepository<User>, EfRepository<User>>();
            services.AddTransient<IRepository<Board>, EfRepository<Board>>();
            services.AddTransient<IRepository<Task>, EfRepository<Task>>();
            services.AddTransient<IRepository<Subtask>, EfRepository<Subtask>>();
            services.AddTransient<IRepository<Note>, EfRepository<Note>>();
            services.AddTransient<IRepository<UserBoard>, EfRepository<UserBoard>>();

            services.AddTransient<IUserRepository, EfUserRepository>();
            services.AddTransient<IBoardRepository, EfBoardRepository>();
            services.AddTransient<ITaskRepository, EfTaskRepository>();
            services.AddTransient<ISubtaskRepository, EfSubtaskRepository>();
            services.AddTransient<INoteRepository, EfNoteRepository>();
            services.AddTransient<IUserBoardRepository, EfUserBoardRepository>();
        }

        private void ConfigureItemServices(IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IBoardService, BoardService>();
            services.AddTransient<ITaskService, TaskService>();
            services.AddTransient<ISubtaskService, SubtaskService>();
            services.AddTransient<INoteService, NoteService>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseMvc();
        }
    }
}
