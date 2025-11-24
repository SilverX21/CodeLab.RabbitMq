For this example, if we want to run a RabbitMQ server using Docker, we can use the following command:

`docker run -d --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:management`

This will spin up a docker container with RabbitMQ and the management plugin enabled. You can access the RabbitMQ management interface by 
navigating to `http://localhost:15672` in your web browser. 
The default username and password are both `guest`.

There you can see the queues, consumers, and some other useful information about your RabbitMQ server.

If we do the basic setup, we will have the basic consumer competing to have messages from the same queue.
If we have 2 consumers and the producer creates 10 messages, it will be distributed between the 2 consumers 
NOTE: check version 1 of the Program.cs in each project "old" folder

We can have multiple queues and have different consumers listening to different queues. 
NOTE: Check version 2 of the Program.cs in each project "old" folder
But that won't scale well if we want to have multiple instances of the same consumer.

For this we can use exchanges.
An exchange is responsible for routing the messages to different queues based on some rules.