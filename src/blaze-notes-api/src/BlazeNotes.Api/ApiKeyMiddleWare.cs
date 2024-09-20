namespace BlazeNotes.API;

public class ApiKeyMiddleWare(RequestDelegate next, IConfiguration configuration)
{
    private const string ApiKeyHeaderName = "api-key";
    private readonly string _configuredApiKey = configuration.GetValue<string>("ApiKey")!;

    public async Task InvokeAsync(HttpContext context)
    {
        if (context.Request.Path.Value!.Equals("/Scalar/v1", StringComparison.OrdinalIgnoreCase))
        {
            await next(context);
            return;
        }

        if (!context.Request.Headers.TryGetValue(ApiKeyHeaderName, out var extractedApiKey))
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("API Key was not provided.");
            return;
        }

        if (string.IsNullOrWhiteSpace(_configuredApiKey) || extractedApiKey != _configuredApiKey)
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Unauthorized client.");
            return;
        }

        await next(context);
    }
}
