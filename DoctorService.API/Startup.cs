﻿using DoctorService.API.Consumer;
using MassTransit;
using Microsoft.OpenApi.Models;

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

            // Register the Swagger generator
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DoctorService API", Version = "v1" });
            });

            services.AddMassTransit(config =>
            {
                var rabbitMqSettings = Configuration.GetSection("RabbitMQ").Get<RabbitMqSettings>();

                config.UsingRabbitMq((ctx, cfg) =>
                {
                    cfg.Host(rabbitMqSettings.Host, rabbitMqSettings.VirtualHost, h =>
                    {
                        h.Username(rabbitMqSettings.UserName);
                        h.Password(rabbitMqSettings.Password);
                    });
                });

                // Add consumers, sagas, etc.
                config.AddConsumer<MessageConsumer>();
            });

            // Register consumers, sagas, etc. as scoped services
            services.AddScoped<MessageConsumer>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.)
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "DoctorService.API");
            });

        }
    }
}