namespace DoctorService.API.Configs
{
    public class ApplicationConfig : IApplicationConfig
    {
        public RabbitMqConfig BusConfig { get; set; } = default!;
    }
}
