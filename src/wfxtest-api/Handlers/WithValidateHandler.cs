using Wolverine;

namespace WfxTest.Api.Handlers;

public class WithValidateRequest
{
}

public static class WithValidateHandler
{
    public static Task<(HandlerContinuation, HandlerResponse)> Validate(
        WithValidateRequest andOutgoingMessagesRequest)
    {
        var validationFailureMessage = new HandlerResponse { Message = "Validation failed in WithValidateHandler!" };

        return Task.FromResult((HandlerContinuation.Stop, validationFailureMessage));
    }

    public static Task<HandlerResponse> Handle(WithValidateRequest andOutgoingMessagesRequest)
    {
        return Task.FromResult(new HandlerResponse { Message = "Hello from WithValidateHandler!" });
    }
}