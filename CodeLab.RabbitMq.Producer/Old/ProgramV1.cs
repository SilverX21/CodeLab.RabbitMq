//using RabbitMQ.Client;

//var factory = new ConnectionFactory { HostName = "localhost" };
//using var connection = await factory.CreateConnectionAsync();
//using var channel = await connection.CreateChannelAsync();

////here we declare the queue we want to use to publish our messages
//await channel.QueueDeclareAsync(queue: "messages",
//    durable: true,  //if it's true, the queue will survive a broker restart, otherwise, they will be deleted, leading to data loss
//    exclusive: false, //this means that the queue is exclusive to the connection that declared it
//    autoDelete: false, //if it's true, the queue will be deleted when there are no more consumers
//    arguments: null);

////await Task.Delay(10_000);

//for (int i = 0; i < 10; i++)
//{
//    string message = $"{DateTime.UtcNow} - {Guid.CreateVersion7()}";
//    var body = System.Text.Encoding.UTF8.GetBytes(message);

//    await channel.BasicPublishAsync(exchange: string.Empty,
//        routingKey: "messages", //this is the queue name we want to publish our message to
//        mandatory: true, //this means it will be routed to a queue
//        basicProperties: new BasicProperties { Persistent = true },
//        body: body);

//    Console.WriteLine($"Sent: {message}");

//    await Task.Delay(2000);
//}

////In the producer, if the messages were sent, but the consumer wasn't up, the messages would be consumed when it comes back online