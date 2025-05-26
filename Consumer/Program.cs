using Consumer;
using Microsoft.Azure.ServiceBus;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddHostedService<CustomerConsumerService>();
builder.Services.AddSingleton<ISubscriptionClient>(x => new SubscriptionClient(
    connectionString: "<servicebus-connection-string>",
    topicPath: "<exampletopic>",
    subscriptionName: "<subscription-name>"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.Run();
