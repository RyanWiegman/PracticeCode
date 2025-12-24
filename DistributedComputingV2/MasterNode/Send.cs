using RabbitMQ.Client;
using System.Text;

namespace MasterNode;

public class Send
{
    public async void CreateConnectionAsync()
    {
        var factory = new ConnectionFactory() { HostName = "localhost" };
        using var connection = await factory.CreateConnectionAsync();
        using var channel = await connection.CreateChannelAsync();

        await channel.QueueDeclareAsync(queue: "hello", durable: false, exclusive: false, autoDelete: false, arguments: null);

        const string message = "Hello World!";
        var body = Encoding.UTF8.GetBytes(message);

        await channel.BasicPublishAsync(exchange: string.Empty, routingKey: "hello", body: body);

        Console.WriteLine($" [x] sent {message}");
        Console.WriteLine("press esc to exit...");

        Console.ReadLine();
    }
}