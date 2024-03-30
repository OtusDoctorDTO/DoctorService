using MassTransit;

namespace DoctorService.API.Consumer
{
    public class MessageConsumer : IConsumer<Message>
    {
        public async Task Consume(ConsumeContext<Message> context)
        {
            // Handle the incoming message
            var message = context.Message;
            Console.WriteLine($"Received message: {message.Text}");
        }
    }

    public class Message
    {
        public string Text { get; set; }
    }
}
