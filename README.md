# ServiceBus Solution

This repository demonstrates a simple message-based communication system using Azure Service Bus with .NET 8.0. It consists of three main projects:

- **Producer**: Publishes messages to an Azure Service Bus topic.
- **Consumer**: Subscribes to the topic and processes incoming messages.
- **Contracts**: Shared message contracts (DTOs) used by both Producer and Consumer.

## Projects Overview

### Producer
- ASP.NET Core Web API for publishing messages.
- Exposes endpoints to publish `CustomerCreated` and `OrderCreated` events.
- Uses `MessagePublisher` service to send messages to Azure Service Bus.

### Consumer
- Background service that listens to the Service Bus topic subscription.
- Processes incoming messages and outputs customer information to the console.

### Contracts
- Contains shared data models: `CustomerCreated` and `OrderCreated`.
- Referenced by both Producer and Consumer projects.

## Prerequisites
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Azure Service Bus](https://azure.microsoft.com/en-us/services/service-bus/) namespace and topic
- Visual Studio 2022 or later (recommended)

## Getting Started

1. **Clone the repository**

   ```powershell
   git clone <repository-url>
   cd ServiceBus
   ```

2. **Configure Azure Service Bus**
   - Update the connection strings and topic/subscription names in `Producer/Program.cs` and `Consumer/Program.cs`:
     - `<service-bus-connection-string>`
     - `<exampletopic>`
     - `<subscription-name>`

3. **Build the solution**

   ```powershell
   dotnet build ServiceBus.sln
   ```

4. **Run the Producer and Consumer**
   - In separate terminals, run:

   ```powershell
   dotnet run --project Producer/Producer.csproj
   dotnet run --project Consumer/Consumer.csproj
   ```

5. **Publish Messages**
   - Use Swagger UI (e.g., `https://localhost:7009/swagger`) or HTTP tools to POST to:
     - `POST /api/messaging/publish/customer`
     - `POST /api/messaging/publish/order`

## Example Message Payloads

**CustomerCreated**
```json
{
  "firstName": "John",
  "lastName": "Doe"
}
```

**OrderCreated**
```json
{
  "id": "123",
  "amount": 100,
  "articleNumber": "A001",
  "customer": {
    "firstName": "John",
    "lastName": "Doe"
  }
}
```

## Notes
- Ensure your Azure Service Bus topic and subscription exist before running the apps.
- The connection strings in the code are placeholders and must be replaced with your actual Azure Service Bus credentials.

## License
This project is for educational/demo purposes.
