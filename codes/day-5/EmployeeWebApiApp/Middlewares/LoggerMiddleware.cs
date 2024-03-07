namespace EmployeeWebApiApp.Middlewares
{
    public class LoggerMiddleware
    {
        RequestDelegate _request;
        public LoggerMiddleware(RequestDelegate request)
        {
            _request = request;
        }
        public async void InvokeAsync(HttpContext context)
        {
            await context.Response.WriteAsync("hello...");       
        }
    }

    public static class MyExtension
    {
        public static void UseMyMiddleware(this IApplicationBuilder app) {
           app.UseMiddleware<LoggerMiddleware>();
        }
    }
}
