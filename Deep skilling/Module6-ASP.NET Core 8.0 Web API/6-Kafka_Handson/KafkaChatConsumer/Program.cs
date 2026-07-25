using Confluent.Kafka;

Console.Title = "Kafka Chat Consumer";

var configuration = new ConsumerConfig
{
    BootstrapServers = "localhost:9092",
    GroupId = "chat-consumer-group",
    AutoOffsetReset = AutoOffsetReset.Earliest,
    EnableAutoCommit = true
};

using var consumer = new ConsumerBuilder<Ignore, string>(configuration)
    .SetErrorHandler((_, error) =>
    {
        Console.WriteLine($"Kafka error: {error.Reason}");
    })
    .Build();

consumer.Subscribe("chat-messages");

Console.WriteLine("===================================");
Console.WriteLine(" Kafka Chat Consumer");
Console.WriteLine("===================================");
Console.WriteLine("Waiting for chat messages...");
Console.WriteLine("Press Ctrl+C to stop.");
Console.WriteLine();

using var cancellationTokenSource = new CancellationTokenSource();

Console.CancelKeyPress += (_, eventArgs) =>
{
    eventArgs.Cancel = true;
    cancellationTokenSource.Cancel();
};

try
{
    while (!cancellationTokenSource.Token.IsCancellationRequested)
    {
        var result = consumer.Consume(
            cancellationTokenSource.Token
        );

        Console.WriteLine(
            $"[{DateTime.Now:HH:mm:ss}] {result.Message.Value}"
        );
    }
}
catch (OperationCanceledException)
{
    Console.WriteLine();
    Console.WriteLine("Consumer stopped.");
}
finally
{
    consumer.Close();
}