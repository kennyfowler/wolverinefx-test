using WfxTest.Api.Handlers;
using Wolverine;

namespace WfxTest.Api;

public static class ValidateMiddlewareWithOutgoingMessages
{
    public static Task<(HandlerContinuation, OutgoingMessages)> Validate(
        WithMiddlewareRequest request)
    {
        var validationFailureMessage = new HandlerResponse
            { Message = "Validation failed in ValidateWithOutgoingMessagesMiddleware!" };

        var outgoingMessages = new OutgoingMessages();
        outgoingMessages.RespondToSender(validationFailureMessage);

        return Task.FromResult((HandlerContinuation.Stop, outgoingMessages));
    }
}