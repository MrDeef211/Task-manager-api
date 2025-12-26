using Api.App.Interfaces;
using Api.Model.Events;
using MediatR;

namespace Api.App.Commands.UpdateTask
{
	/// <summary>
	/// Обновление задачи
	/// Используется как прослойка между медиатором и сервисом
	/// </summary>
	public class UpdateTaskHandler : IRequestHandler<UpdateTask, Unit>
	{
		private readonly ITaskService _taskService;

		public UpdateTaskHandler(ITaskService taskService)
		{
			_taskService = taskService;
		}

		public async Task<Unit> Handle(UpdateTask taskData, CancellationToken ct)
		{
			await _taskService.UpdateAsync(taskData);
			return Unit.Value;
		}
	}
}
