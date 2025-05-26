
using Contracts;
using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;
using System.Text;

namespace Consumer
{
    public class CustomerConsumerService : BackgroundService
    {
        private readonly ISubscriptionClient _subscriptionClient;

        public CustomerConsumerService(ISubscriptionClient subscriptionClient)
        {
            _subscriptionClient = subscriptionClient;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _subscriptionClient.RegisterMessageHandler((message, token) =>
            {
                var customerCreated = JsonConvert.DeserializeObject<CustomerCreated>(Encoding.UTF8.GetString(message.Body));
                Console.WriteLine($"New customer with name: {customerCreated.FirstName} {customerCreated.LastName}");
                return _subscriptionClient.CompleteAsync(message.SystemProperties.LockToken);
            }, new MessageHandlerOptions(args => Task.CompletedTask)
            {
                AutoComplete = false,
                MaxConcurrentCalls = 1
            });
            return Task.CompletedTask;
        }
    }
}
