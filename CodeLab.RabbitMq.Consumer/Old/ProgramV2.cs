//using System.Text;
//using RabbitMQ.Client;
//using RabbitMQ.Client.Events;

//Console.WriteLine("Consumer 1");

//var factory = new ConnectionFactory { HostName = "localhost" };
//using var connection = await factory.CreateConnectionAsync();
//using var channel = await connection.CreateChannelAsync();

////here we declare the queue we want to use to publish our messages
//await channel.QueueDeclareAsync(queue: "messages-1", durable: true, exclusive: false, autoDelete: false, arguments: null);

//Console.WriteLine("Waiting for messages...");

//var consumer = new AsyncEventingBasicConsumer(channel); //here we create the consumer

////this event will be triggered when a message is received
////this is the consumer delegate that will process the messages
//consumer.ReceivedAsync += async (sender, eventArgs) =>
//{
//    byte[] body = eventArgs.Body.ToArray();
//    string message = Encoding.UTF8.GetString(body);

//    Console.WriteLine($"Received: {message}");

//    //here we acknowledge that the message has been processed
//    //here we are only acknowledging the single message we just processed (multiple: false
//    await ((AsyncEventingBasicConsumer)sender).Channel.BasicAckAsync(eventArgs.DeliveryTag, multiple: false);
//};

////here we start consuming messages from the queue
//await channel.BasicConsumeAsync(queue: "messages-1", autoAck: false, consumer: consumer);

//Console.ReadLine();