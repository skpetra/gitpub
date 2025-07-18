namespace WebAPI.Modules.Quizzes.Features.GetQuizzes;

using FastEndpoints;

public class HelloEndpoint : EndpointWithoutRequest<string>
{
    public override void Configure()
    {
        Get("/hello");
        AllowAnonymous();
        Description(b => b
            .WithSummary("Returns a hello message")
            .WithDescription("This endpoint returns a simple hello message for testing purposes.")
        );
    }

    public override Task HandleAsync(CancellationToken ct)
    {
        Response = "Hello, FastEndpoints!";
        return Task.CompletedTask;
    }
}
