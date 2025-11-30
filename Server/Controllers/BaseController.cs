using Core.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Server.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        protected string GetTokenFromHeaders() =>
            Request.Headers.Authorization.FirstOrDefault()!.Split(" ").Last();
    }

    public sealed class ApiExceptionFilter : IAsyncExceptionFilter
    {
        public Task OnExceptionAsync(ExceptionContext context)
        {
            if (context.Exception is ApiException apiEx)
            {
                context.Result = new ObjectResult(new { detail = apiEx.Message })
                {
                    StatusCode = apiEx.StatusCode,
                };

                context.ExceptionHandled = true;
            }

            return Task.CompletedTask;
        }
    }
}
