namespace WfxTest.Api.Handlers;

public class WithMiddlewareRequest
{
}

public static class WithMiddlewareHandler
{
    public static Task<HandlerResponse> Handle(WithMiddlewareRequest request)
    {
        return Task.FromResult(new HandlerResponse { Message = "Hello from WithMiddlewareHandler!" });
    }
}