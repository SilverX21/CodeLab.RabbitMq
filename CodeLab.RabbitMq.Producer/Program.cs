using System.Text;
using RabbitMQ.Client;

Console.WriteLine("Producer");

var factory = new ConnectionFactory { HostName = "localhost" };
using var connection = await factory.CreateConnectionAsync();
using var channel = await connection.CreateChannelAsync();

//here we can create an exchange
await channel.ExchangeDeclareAsync(exchange: "messages",
    durable: true,
    autoDelete: false,
    type: ExchangeType.Fanout // fanout will broadcast to all queues bound to it
    );

await Task.Delay(10_000);

for (int i = 0; i < 10; i++)
{
    string message = $"Message {i + 1}: {DateTime.UtcNow} - {Guid.CreateVersion7()}";
    var body = Encoding.UTF8.GetBytes(message);

    await channel.BasicPublishAsync(
        exchange: "messages", //here we specify the exchange we want to publish the message to
        routingKey: string.Empty,
        mandatory: true,
        basicProperties: new BasicProperties { Persistent = true },
        body: body);

    Console.WriteLine($"Sent: {message}");

    await Task.Delay(2000);
}

//In the producer, if the messages were sent, but the consumer wasn't up, the messages would be consumed when it comes back online