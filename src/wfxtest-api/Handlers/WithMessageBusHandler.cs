using Wolverine;

namespace WfxTest.Api.Handlers;

public class WithMessageBusRequest
{
}

public static class WithMessageBusHandler
{
    public static Task<HandlerContinuation> Validate(WithMessageBusRequest request, IMessageBus messageBus)
    {
        var validationFailureMessage = new HandlerResponse { Message = "Validation failed in WithMessageBusHandler!" };

        messageBus.PublishAsync(validationFailureMessage);

        return Task.FromResult(HandlerContinuation.Stop);
    }

    public static Task<HandlerResponse> Handle(WithMessageBusRequest request)
    {
        return Task.FromResult(new HandlerResponse { Message = "Hello from WithMessageBusHandler!" });
    }
}