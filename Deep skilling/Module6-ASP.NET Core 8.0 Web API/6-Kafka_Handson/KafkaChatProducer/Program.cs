using Confluent.Kafka;

Console.Title = "Kafka Chat Producer";

var configuration = new ProducerConfig
{
    BootstrapServers = "localhost:9092"
};

using var producer = new ProducerBuilder<Null, string>(
    configuration
).Build();

Console.WriteLine("===================================");
Console.WriteLine(" Kafka Chat Producer");
Console.WriteLine("===================================");

Console.Write("Enter your name: ");
string userName = Console.ReadLine()?.Trim() ?? "Anonymous";

if (string.IsNullOrWhiteSpace(userName))
{
    userName = "Anonymous";
}

Console.WriteLine();
Console.WriteLine("Type a chat message and press Enter.");
Console.WriteLine("Type 'exit' to close the producer.");
Console.WriteLine();

while (true)
{
    Console.Write($"{userName}: ");

    string? input = Console.ReadLine();

    if (string.Equals(
            input,
            "exit",
            StringComparison.OrdinalIgnoreCase))
    {
        break;
    }

    if (string.IsNullOrWhiteSpace(input))
    {
        continue;
    }

    string chatMessage = $"{userName}: {input}";

    try
    {
        DeliveryResult<Null, string> result =
            await producer.ProduceAsync(
                "chat-messages",
                new Message<Null, string>
                {
                    Value = chatMessage
                }
            );

        Console.WriteLine(
            $"Message published to " +
            $"{result.TopicPartitionOffset}"
        );
    }
    catch (ProduceException<Null, string> exception)
    {
        Console.WriteLine(
            $"Message delivery failed: " +
            $"{exception.Error.Reason}"
        );
    }
}

producer.Flush(TimeSpan.FromSeconds(10));

Console.WriteLine("Producer closed.");