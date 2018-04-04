using System;
using RabbitMQ.Client;
using System.Text;

class Send
{
    public static void Main(string[] args)
    {
	var mqhostname = Environment.GetEnvironmentVariable("RABBITMQ_HOST");
	if (mqhostname.Length == 0)
	{
    	    Console.WriteLine("Please inject env variable RABBITMQ_HOST.");
    	    return;
	}

	Console.WriteLine("Send Argument:" + mqhostname);
        var factory = new ConnectionFactory() { HostName = mqhostname };
        using(var connection = factory.CreateConnection())
        using(var channel = connection.CreateModel())
        {
            channel.QueueDeclare(queue: "hello", durable: false, exclusive: false, autoDelete: false, arguments: null);

            string message = "Hello World!";
            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(exchange: "", routingKey: "hello", basicProperties: null, body: body);
            Console.WriteLine(" [x] Sent {0}", message);
        }

        Console.WriteLine(" Press [enter] to exit.");
        Console.ReadLine();
    }
}
