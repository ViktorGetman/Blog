namespace Blog.Middleware;

public class JwtMiddleware
{
    private readonly RequestDelegate _next;

    public JwtMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        var token = context.Request.Cookies["token"] ?? context.Session.GetString("token");

        if (token != null)
        {
            context.Request.Headers["Authorization"] = "Bearer " + token;
        }

        await _next(context);
    }
}