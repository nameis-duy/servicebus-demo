namespace Producer.Services
{
    public interface IMessagePublisher
    {
        Task Publish<T>(T message);
        Task Publish(string message);
    }
}
