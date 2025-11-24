For this example, if we want to run a RabbitMQ server using Docker, we can use the following command:

`docker run -d --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:management`

This will spin up a docker container with RabbitMQ and the management plugin enabled. You can access the RabbitMQ management interface by 
navigating to `http://localhost:15672` in your web browser. 
The default username and password are both `guest`.

There you can see the queues, consumers, and some other useful information about your RabbitMQ server.