using DoctorService.API.Configs;
using DoctorService.API.Consumer;
using DoctorService.Data.Context;
using DoctorService.Data.Repositories;
using DoctorService.Domain.Repositories;
using DoctorService.Domain.Services;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile("appsettings.Development.json", true)
                .Build();

            if (configuration.Get<ApplicationConfig>() is not IApplicationConfig receptionConfig)
                throw new ConfigurationException("Не удалось прочитать конфигурацию сервиса");

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DoctorService API", Version = "v1" });
            });

            services.AddMassTransit(x =>
            {
                x.AddConsumer<DoctorConsumer>();


                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(receptionConfig.BusConfig.Host, receptionConfig.BusConfig.Port, receptionConfig.BusConfig.Path, h =>
                    {
                        h.Username(receptionConfig.BusConfig.Username);
                        h.Password(receptionConfig.BusConfig.Password);
                    });

                    cfg.UseTransaction(_ =>
                    {
                        _.Timeout = TimeSpan.FromSeconds(60);
                        _.IsolationLevel = IsolationLevel.ReadCommitted;
                    });

                    cfg.ReceiveEndpoint(new TemporaryEndpointDefinition(), e =>
                    {
                        e.ConfigureConsumer<DoctorConsumer>(context);
                    });
                    cfg.ConfigureEndpoints(context);
                });
            });

            string connection = configuration.GetConnectionString("DefaultConnection");
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
