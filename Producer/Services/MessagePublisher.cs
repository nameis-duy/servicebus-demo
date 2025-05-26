
using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;
using System.Text;

namespace Producer.Services
{
    public class MessagePublisher : IMessagePublisher
    {
        private readonly ITopicClient _topicClient;

        public MessagePublisher(ITopicClient topicClient)
        {
            _topicClient = topicClient;
        }

        public Task Publish<T>(T message)
        {
            var objStr = JsonConvert.SerializeObject(message);
            var encodedMsg = new Message(Encoding.UTF8.GetBytes(objStr));
            encodedMsg.UserProperties["messageType"] = typeof(T).Name;
            return _topicClient.SendAsync(encodedMsg);
        }

        public Task Publish(string message)
        {
            var encodedMessage = new Message(Encoding.UTF8.GetBytes(message));
            return _topicClient.SendAsync(encodedMessage);
        }
    }
}
