using Api.Model.Exceptions;
using Serilog;

namespace Api.Middleware
{
	/// <summary>
	/// Обработчик исключений
	/// </summary>
	public class ExceptionHandlingMiddleware
	{
		private readonly RequestDelegate _next;
		private readonly ILogger<ExceptionHandlingMiddleware> _logger;

		public ExceptionHandlingMiddleware(
			RequestDelegate next, 
			ILogger<ExceptionHandlingMiddleware> logger)
		{
			_next = next;
			_logger = logger;
		}

		public async Task Invoke(HttpContext context)
		{
			try
			{
				await _next(context);
			}
			catch (DomainException ex)
			{
				context.Response.StatusCode = StatusCodes.Status400BadRequest;
				context.Response.ContentType = "application/json";

				await context.Response.WriteAsJsonAsync(new
				{
					error = ex.Message
				});
			}
			catch (Exception ex)
			{
			    _logger.LogError(
			       ex,
			       "Unhandled exception. Path: {Path}, Method: {Method}",
			       context.Request.Path,
			       context.Request.Method
			    );

				context.Response.StatusCode = StatusCodes.Status500InternalServerError;

				await context.Response.WriteAsJsonAsync(new
				{
					error = "Внутренняя ошибка сервера"
				});
			}
		}
	}
}
