using Api.App.Commands.CreateTask;
using Api.App.Commands.UpdateTask;
using Api.App.Commands.CompleteTask;
using Api.App.Commands.StartTask;
using Api.App.Commands.DeleteTask;

using Api.App.Queries.GetTasks;
using Api.App.Queries.GetTaskById;

using Api.App.Objects;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Api.Model.Exceptions;



namespace Api.Controllers
{
	[ApiController]
	[Route("api/tasks")]
	public class TasksController : ControllerBase
	{
		private readonly IMediator _mediator;

		public TasksController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] CreateTask taskData)
		{
			await _mediator.Send(taskData);
			return Ok();
		}

		[HttpPut("{id:guid}")]
		public async Task<IActionResult> Update(Guid id, [FromBody] UpdateTask taskData)
		{
			await _mediator.Send(taskData);
		    return Ok();
		}

		[HttpPut("{id:guid}/start")]
		public async Task<IActionResult> StartTask(Guid id)
		{
			await _mediator.Send(new StartTask(id));
			return Ok();
		}

		[HttpPut("{id:guid}/complete")]
		public async Task<IActionResult> CompleteTask(Guid id)
		{
			await _mediator.Send(new CompleteTask(id));
			return Ok();
		}

		[HttpGet]
		public async Task<ActionResult<List<TaskDto>>> Get([FromQuery] GetTasks taskData)
		{
			var result = await _mediator.Send(taskData);
			return Ok(result);
		}

		[HttpGet("{id:guid}")]
		public async Task<ActionResult<TaskDto>> GetById(Guid id)
		{
			var result = await _mediator.Send(new GetTaskById(id));
			return Ok(result);
		}


		[HttpDelete("{id:guid}")]
		public async Task<IActionResult> Delete(Guid id)
		{
			await _mediator.Send(new DeleteTask(id));
			return NoContent();
		}

	}
}
