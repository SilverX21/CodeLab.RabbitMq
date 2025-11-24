using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

Console.WriteLine("Consumer 2");

var factory = new ConnectionFactory { HostName = "localhost" };
using var connection = await factory.CreateConnectionAsync();
using var channel = await connection.CreateChannelAsync();

//first we declare the exchange we want to use
await channel.ExchangeDeclareAsync(exchange: "messages",
    durable: true,
    autoDelete: false,
    type: ExchangeType.Fanout
    );

//here we declare the queue we want to use to publish our messages
await channel.QueueDeclareAsync(
    queue: "messages-2",
    durable: true,
    exclusive: false,
    autoDelete: false,
    arguments: null);

//here we bind our queue "messages-2" to the "messages" exchange
await channel.QueueBindAsync("messages-2", "messages", string.Empty);

Console.WriteLine("Waiting for messages...");

var consumer = new AsyncEventingBasicConsumer(channel); //here we create the consumer

//this event will be triggered when a message is received
//this is the consumer delegate that will process the messages
consumer.ReceivedAsync += async (sender, eventArgs) =>
{
    byte[] body = eventArgs.Body.ToArray();
    string message = Encoding.UTF8.GetString(body);

    Console.WriteLine($"Received: {message}");

    //here we acknowledge that the message has been processed
    //here we are only acknowledging the single message we just processed (multiple: false
    await ((AsyncEventingBasicConsumer)sender).Channel.BasicAckAsync(eventArgs.DeliveryTag, multiple: false);
};

//here we start consuming messages from the queue
await channel.BasicConsumeAsync(queue: "messages-2", autoAck: false, consumer: consumer);

Console.ReadLine();