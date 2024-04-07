using DoctorService.API.Consumer;
using DoctorService.Data.Context;
using DoctorService.Data.Repositories;
using DoctorService.Domain.Repositories;
using DoctorService.Domain.Services;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Transactions;

namespace DoctorService.API
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
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DoctorService API", Version = "v1" });
            });

            services.AddMassTransit(config =>
            {
                config.AddConsumer<DoctorConsumer>();

                var rabbitMqSettings = Configuration.GetSection("RabbitMQ").Get<RabbitMqSettings>();

                config.UsingRabbitMq((ctx, cfg) =>
                {
                    cfg.Host(rabbitMqSettings.Host, rabbitMqSettings.VirtualHost, h =>
                    {
                        h.Username(rabbitMqSettings.UserName);
                        h.Password(rabbitMqSettings.Password);
                    });

                    cfg.UseTransaction(_ =>
                    {
                        _.Timeout = TimeSpan.FromSeconds(60);
                        _.IsolationLevel = IsolationLevel.ReadCommitted;
                    });

                    cfg.ReceiveEndpoint(new TemporaryEndpointDefinition(), e =>
                    {
                        e.ConfigureConsumer<DoctorConsumer>(ctx);
                    });
                    cfg.ConfigureEndpoints(ctx);
                });

                config.AddConsumer<DoctorConsumer>();
            });

            string connection = Configuration.GetConnectionString("DefaultConnection");
            if (string.IsNullOrEmpty(connection))
                throw new ConfigurationException("Не удалось прочитать строку подключения");

            services.AddDbContext<DoctorDbContext>(options => options.UseSqlServer(connection));

            services.AddTransient<IDoctorService, Services.DoctorService>();
            services.AddTransient<IDoctorRepository, DoctorRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "DoctorService.API");
            });

        }
    }
}
