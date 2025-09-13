using JasperFx;
using WfxTest.Api;
using WfxTest.Api.Handlers;
using Wolverine;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseWolverine(options =>
{
    //options.Durability.Mode = DurabilityMode.MediatorOnly;
    options.Policies.ForMessagesOfType<WithMiddlewareRequest>()
        .AddMiddleware(typeof(ValidateMiddlewareWithOutgoingMessages));
});

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/default", (IMessageBus messageBus) =>
{
    var response = messageBus.InvokeAsync<HandlerResponse>(new DefaultRequest());

    return response;
});

app.MapGet("/with-validate", (IMessageBus messageBus) =>
{
    var response = messageBus.InvokeAsync<HandlerResponse>(new WithValidateRequest());

    return response;
});

app.MapGet("/with-validate-outgoing", (IMessageBus messageBus) =>
{
    var response = messageBus.InvokeAsync<HandlerResponse>(new WithValidateAndOutgoingMessagesRequest());

    return response;
});

app.MapGet("/with-middleware", (IMessageBus messageBus) =>
{
    var response = messageBus.InvokeAsync<HandlerResponse>(new WithMiddlewareRequest());

    return response;
});

app.MapGet("/with-messagebus", (IMessageBus messageBus) =>
{
    var response = messageBus.InvokeAsync<HandlerResponse>(new WithMessageBusRequest());

    return response;
});

app.RunJasperFxCommandsSynchronously(args);