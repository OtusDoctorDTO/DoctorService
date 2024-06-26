using DoctorService.API.Configs;
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
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true)
                .Build();

            if (configuration.Get<ApplicationConfig>() is not IApplicationConfig receptionConfig)
                throw new ConfigurationException("�� ������� ��������� ������������ �������");

            string connection = configuration!.GetConnectionString("DefaultConnection");
            if (string.IsNullOrEmpty(connection))
                throw new ConfigurationException("�� ������� ��������� ������ �����������");

            builder.Services.AddDbContext<DoctorDbContext>(options => options.UseSqlServer(connection));

            builder.Services.AddTransient<IDoctorRepository, DoctorRepository>();
            builder.Services.AddTransient<IDoctorService, DoctorService.API.Services.DoctorService>();

            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });
            builder.Services.AddMassTransit(x =>
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

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger(c =>
                {
                    c.RouteTemplate = "/swagger/{documentName}/swagger.json";
                });
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
            }
            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}