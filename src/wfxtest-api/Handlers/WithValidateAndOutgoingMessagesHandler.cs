using Wolverine;

namespace WfxTest.Api.Handlers;

public class WithValidateAndOutgoingMessagesRequest
{
}

public static class WithValidateAndOutgoingMessagesHandler
{
    public static Task<(HandlerContinuation, OutgoingMessages)> Validate(
        WithValidateAndOutgoingMessagesRequest andOutgoingMessagesRequest)
    {
        var validationFailureMessage = new HandlerResponse
            { Message = "Validation failed in WithValidateAndOutgoingMessagesHandler!" };

        var outgoingMessages = new OutgoingMessages();
        outgoingMessages.RespondToSender(validationFailureMessage);

        return Task.FromResult((HandlerContinuation.Stop, outgoingMessages));
    }

    public static Task<HandlerResponse> Handle(WithValidateAndOutgoingMessagesRequest andOutgoingMessagesRequest)
    {
        return Task.FromResult(new HandlerResponse { Message = "Hello from WithValidateAndOutgoingMessagesHandler!" });
    }
}