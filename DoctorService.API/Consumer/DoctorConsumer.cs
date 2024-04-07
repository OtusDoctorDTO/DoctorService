using DoctorService.Domain.Services;
using MassTransit;

namespace DoctorService.API.Consumer
{
    public class DoctorConsumer : IConsumer<GetDoctorsDTORequest>
    {
        private readonly ILogger<DoctorConsumer> _logger;
        private readonly IDoctorService _service;
        public async Task Consume(ILogger<DoctorConsumer> logger, IDoctorService service)
        {
            _logger = logger;
            _service = service;
        }

        public Task Consume(ConsumeContext<GetDoctorsDTORequest> context)
        {
            logger.LogInformation("Получен запрос GetDoctorsDTOResponse {message}", context.Message);
            var result = new GetDoctorsDTOResponse()
            {
                Guid = context.Message.Guid,
                Success = true,
                ConnectionId = context.Message.ConnectionId
            };
            try
            {
                result.Doctors = await service.GetAllDoctors();
            }
            catch (System.Exception e)
            {
                logger.LogError(e, "При сохранении пациента произошла ошибка");
            }
            await context.RespondAsync(result);
        }
    }
}
