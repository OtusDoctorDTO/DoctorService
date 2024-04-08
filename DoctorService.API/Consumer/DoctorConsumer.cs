using DoctorService.Domain.Services;
using HelpersDTO.Doctor.DTO;
using MassTransit;

namespace DoctorService.API.Consumer
{
    public class DoctorConsumer : IConsumer<GetDoctorsDTORequest>
    {
        private readonly ILogger<DoctorConsumer> _logger;
        private readonly IDoctorService _service;
        public DoctorConsumer(ILogger<DoctorConsumer> logger, IDoctorService service)
        {
            _logger = logger;
            _service = service;
        }

        public async Task Consume(ConsumeContext<GetDoctorsDTORequest> context)
        {
            _logger.LogInformation("Получен запрос GetDoctorsDTOResponse {message}", context.Message);
            var result = new GetDoctorsDTOResponse()
            {
                Guid = context.Message.Guid,
                Success = true,
                ConnectionId = context.Message.ConnectionId
            };
            try
            {
                var doctors = await _service.GetAll();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "При сохранении произошла ошибка");
            }
            await context.RespondAsync(result);
        }
    }
}
