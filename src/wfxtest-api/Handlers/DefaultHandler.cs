namespace WfxTest.Api.Handlers;

public class DefaultRequest
{
}

public static class DefaultHandler
{
    public static Task<HandlerResponse> Handle(DefaultRequest request)
    {
        return Task.FromResult(new HandlerResponse { Message = "Hello from DefaultHandler!" });
    }
}