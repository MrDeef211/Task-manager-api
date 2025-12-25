using Microsoft.AspNetCore.Mvc;
using Api.App.Commands.CreateTask;
using Api.App.Queries.GetTaskById;

namespace Api.Controllers
{
	[ApiController]
	[Route("tasks")]
	public class TasksController : ControllerBase
	{
		private readonly CreateTaskHandler _createHandler;
		private readonly GetTaskByIdHandler _getByIdHandler;

		public TasksController(
			CreateTaskHandler createHandler,
			GetTaskByIdHandler getByIdHandler)
		{
			_createHandler = createHandler;
			_getByIdHandler = getByIdHandler;
		}

		[HttpPost]
		public async Task<IActionResult> Create(CreateTaskRequest request)
		{
			var id = await _createHandler.HandleAsync(new CreateTaskCommand
			{
				Title = request.Title,
				Description = request.Description,
				Deadline = request.Deadline
			});

			return CreatedAtAction(nameof(GetById), new { id }, null);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(Guid id)
		{
			var result = await _getByIdHandler.HandleAsync(new GetTaskByIdQuery
			{
				TaskId = id
			});

			if (result == null)
				return NotFound();

			return Ok(result);
		}
	}
}
